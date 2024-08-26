from PyQt6.QtCore import QObject, pyqtSignal, QThread

from change_hosts import ChangeHosts
from dns_servers import dns_servers
from get_dns import query_domain


class DomainViewModel(QObject):
    server_list_changed = pyqtSignal()

    def __init__(self, domain: str):
        super().__init__()
        self.domain = domain
        self.server_list = []
        self.server_list_view = dict()
        self.fetch_ip_addresses()

    def on_reset_button_clicked(self):
        # reset_button을 클릭하면 hosts 파일을 초기화
        ChangeHosts(self.domain, "").remove()

    def add_server(self, server: str):
        if server not in self.server_list:
            # 서버가 중복되지 않도록 추가
            self.server_list.append(server)
            # 서버 리스트를 정렬
            self.server_list = sorted(self.server_list)
            # 서버 리스트가 변경되었음을 알림
            self.server_list_changed.emit()

    def fetch_ip_addresses(self):
        self.workers = []
        for dns_server in dns_servers:
            self.workers.append(DomainWorker(self.domain, dns_server))

        for worker in self.workers:
            worker.finished.connect(self.add_server)
            worker.start()


# 스레드 기반으로 DNS 서버로부터 도메인의 IP 주소를 가져오는 클래스
class DomainWorker(QThread):
    finished = pyqtSignal(str)

    def __init__(self, domain: str, dns_servers: str):
        super().__init__()
        self.domain = domain
        self.dns_servers = dns_servers
        self._running = True

    def run(self):
        ip_list = query_domain(self.domain, [self.dns_servers])
        for ip in ip_list:
            if not self._running:
                break
            self.finished.emit(ip)

    def stop(self):
        self.quit()
        self.wait()
