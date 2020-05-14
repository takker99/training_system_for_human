using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Markup;
using Prism.Mvvm;

namespace DynamicFrameTest.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string _title = "Prism Application";
        public string Title
        {
            get => this._title;
            set => this.SetProperty(ref this._title, value);
        }
        public FlowDocument Document { get; }

        public MainWindowViewModel()
        {
            using FileStream stream = File.OpenRead(@"pages/Page1.xaml");
            this.Document = XamlReader.Load(stream) as FlowDocument;
            // 動的にevent handlerを指定する
            (this.Document.FindName("button1") as Button).Click += (s, e) =>
              {
                  // 動的にpropertyを読み込む
                  var textBox = this.Document.FindName("answer1") as TextBox;
                  _ = MessageBox.Show(textBox.Text);
              };
        }
    }
}
