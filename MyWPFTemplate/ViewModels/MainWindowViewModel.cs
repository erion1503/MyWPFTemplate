using Livet;
using Livet.Commands;
using Livet.Messaging.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MyWPFTemplate.ViewModels
{
    class MainWindowViewModel : ViewModel
    {
        #region プロパティ

        #endregion
        #region コマンド
        #region 最小化コマンド
        private ViewModelCommand minimizeCommand;
        public ViewModelCommand MinimizeCommand
        {
            get
            {
                if (minimizeCommand == null)
                    minimizeCommand = new ViewModelCommand(Minimize);
                return minimizeCommand;
            }
        }
        private void Minimize()
        {
            Messenger.Raise(new WindowActionMessage(WindowAction.Minimize, "Minimize"));
        }

        #endregion
        #region リサイズコマンド
        private ListenerCommand<object> resizeCommand;
        public ListenerCommand<object> ResizeCommand
        {
            get
            {
                if (resizeCommand == null)
                    resizeCommand = new ListenerCommand<object>(Resize);
                return resizeCommand;
            }
        }
        private void Resize(object obj)
        {
            var window = (Window)obj;
            if (window.WindowState == WindowState.Maximized)
                Messenger.Raise(new WindowActionMessage(WindowAction.Normal, "Normal"));
            else
                Messenger.Raise(new WindowActionMessage(WindowAction.Maximize, "Maximize"));
        }
        #endregion
        #region 閉じるコマンド
        private ViewModelCommand closeCommand;
        public ViewModelCommand CloseCommand
        {
            get
            {
                if (closeCommand == null)
                    closeCommand = new ViewModelCommand(Close);
                return closeCommand; }

        }
        private void Close()
        {
            Messenger.Raise(new WindowActionMessage(WindowAction.Close, "Close"));
        }
        #endregion
        #endregion
        #region コンストラクタ

        #endregion
    }
}
