using Prism.Regions;
using System.Windows;

namespace CustomRegionAdapter.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IRegionManager _regionManager;
        #region Seq_5 MainWindow 설명
        // Container.Resolve에서 정해지면 생성자로 넘어간다....
        #endregion
        public MainWindow(IRegionManager regionManager)
        {
            InitializeComponent();
            _regionManager = regionManager;
        }

        #region Seq_8 CreateShell 설명
        // 처음에 RegisterForNavigation로 ViewA를 등록한 것을 RequestNavigate로 받아서
        // ContentRegion이라는 키와 함께 보낸다.
        #endregion
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //ContentRegion이라는 곳에 ViewA의 값을 집어넣어라
            // _regionManager.Regions["ContentRegion"].Add(new ViewA());
            _regionManager.RequestNavigate("ContentRegion", "ViewA");
        }
    }
}
