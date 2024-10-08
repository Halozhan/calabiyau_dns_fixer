from PyQt6.QtWidgets import (
    QMainWindow,
    QHBoxLayout,
    QWidget,
    QTabWidget,
)


from viewmodels.manual_ip_view_model import ManualIPViewModel
from viewmodels.domain_view_model import DomainViewModel

from ..widgets.domain_widget import DomainWidget
from models.domains import domains
from views.widgets.manual_ip_view import ManualIPView


class MainView(QMainWindow):
    def __init__(self):
        super().__init__()
        self.initUI()

    def initUI(self):
        self.setWindowTitle(
            "Calabiyau(卡拉彼丘) Server Node Changer - \
Please restart your game after changing the server"
        )
        # Tab Widget
        self.tab_widget = QTabWidget()
        # Set the central widget of the Window.
        # Widget will expand to take up all the space in the window by default
        self.setCentralWidget(self.tab_widget)

        # Main Tab
        self.main_tab = QWidget()
        self.main_tab_layout = QHBoxLayout()

        # Domain view
        for domain in domains:
            self.domain_view_model = DomainViewModel(domain)
            self.domain_view = DomainWidget(domain, self.domain_view_model)
            self.main_tab_layout.addWidget(self.domain_view)

        self.main_tab.setLayout(self.main_tab_layout)
        self.tab_widget.addTab(self.main_tab, "Main")

        # 수동으로 등록된 IP 주소를 표시하는 탭
        self.manual_tab = QWidget()
        self.manual_tab_layout = QHBoxLayout()

        # Manual IP View
        self.tianjin_view_model = ManualIPViewModel("ds-tj-1.klbq.qq.com")
        self.tianjin = ManualIPView(
            domain="ds-tj-1.klbq.qq.com",
            server_list=[
                "109.244.173.239",
                "109.244.173.251",
                "111.30.170.175",
                "111.33.110.226",
                "116.130.228.105",
                "116.130.229.177",
                "123.151.54.47",
                "42.81.194.60",
                "43.159.233.14",
            ],
            view_model=self.tianjin_view_model,
        )
        self.manual_tab_layout.addWidget(self.tianjin)

        self.nanjing_view_model = ManualIPViewModel("ds-nj-1.klbq.qq.com")
        self.nanjing = ManualIPView(
            domain="ds-nj-1.klbq.qq.com",
            server_list=[
                "112.80.183.27",
                "121.229.92.16",
                "180.110.193.185",
                "182.50.15.118",
                "36.155.164.82",
                "36.155.183.208",
                "43.141.129.109",
                "43.141.129.21",
                "43.159.233.198",
            ],
            view_model=self.nanjing_view_model,
        )
        self.manual_tab_layout.addWidget(self.nanjing)

        self.guangzhou_view_model = ManualIPViewModel("ds-gz-1.klbq.qq.com")
        self.guangzhou = ManualIPView(
            domain="ds-gz-1.klbq.qq.com",
            server_list=[
                "120.232.24.96",
                "120.233.18.175",
                "14.29.103.46",
                "157.148.58.53",
                "157.255.4.48",
                "183.47.107.193",
                "43.139.252.183",
                "43.141.58.200",
                "43.159.233.178",
            ],
            view_model=self.guangzhou_view_model,
        )
        self.manual_tab_layout.addWidget(self.guangzhou)

        self.chongqing_view_model = ManualIPViewModel("ds-cq-1.klbq.qq.com")
        self.chongqing = ManualIPView(
            domain="ds-cq-1.klbq.qq.com",
            server_list=[
                "111.10.11.250",
                "111.10.11.73",
                "113.250.9.54",
                "113.250.9.56",
                "175.27.48.249",
                "175.27.49.194",
                "43.159.233.98",
                "58.144.164.43",
                "58.144.164.50",
            ],
            view_model=self.chongqing_view_model,
        )
        self.manual_tab_layout.addWidget(self.chongqing)

        self.manual_tab.setLayout(self.manual_tab_layout)
        self.tab_widget.addTab(self.manual_tab, "Manually registered list")
