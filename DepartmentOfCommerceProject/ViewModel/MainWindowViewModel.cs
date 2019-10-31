using DepartmentOfCommerceProject.Infrastructure.BusinessObjects;
using DepartmentOfCommerceProject.Infrastructure.Commands;
using System;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Input;

namespace DepartmentOfCommerceProject.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        public ObservableCollection<TreeViewNode> TreeViewContent { get; private set; } //= new ObservableCollection<TreeViewNode>()
        //{
        //            new TreeViewNode("Продажи", IconType.folder, new ObservableCollection<TreeViewNode>()
        //            {
        //                new TreeViewNode("Выписка накладных", IconType.item)
        //            }),
        //         new TreeViewNode("Розничная торговля", IconType.folder, new ObservableCollection<TreeViewNode>()
        //            {
        //                new TreeViewNode("Кассовые операции", IconType.item),
        //                new TreeViewNode("POS", IconType.item),
        //                new TreeViewNode("Печать ценников ТСД", IconType.item),
        //                new TreeViewNode("Обработка Z-отчетов", IconType.item),
        //                new TreeViewNode("Переоценка", IconType.item),
        //                new TreeViewNode("Подарочные сертификаты", IconType.item),
        //                new TreeViewNode("Выписка подарочных сертификатов", IconType.item)
        //            }),
        //         new TreeViewNode("Закупка", IconType.folder, new ObservableCollection<TreeViewNode>()
        //            {
        //                new TreeViewNode("Заказы по потребностям", IconType.item),
        //                new TreeViewNode("Графики заказов", IconType.item),
        //                new TreeViewNode("Заказы по графику", IconType.item),
        //                new TreeViewNode("Приемка по заказам", IconType.item),
        //                new TreeViewNode("Обновление розничных цен", IconType.item)
        //            }),
        //         new TreeViewNode("Цены", IconType.folder, new ObservableCollection<TreeViewNode>()
        //            {
        //                new TreeViewNode("Управление ценами", IconType.item),
        //                new TreeViewNode("Текущие цены", IconType.item),
        //                new TreeViewNode("Розничные цены", IconType.item)
        //            }),
        //          new TreeViewNode("Задолженности", IconType.folder, new ObservableCollection<TreeViewNode>()
        //            {
        //                new TreeViewNode("Управление задолженностями", IconType.item),
        //                new TreeViewNode("Разнесение документов", IconType.item),
        //                new TreeViewNode("Неоплаченные документы", IconType.item)
        //            }),
        //           new TreeViewNode("Маркетинг", IconType.folder, new ObservableCollection<TreeViewNode>()
        //            {
        //                new TreeViewNode("Договоры маркетинга", IconType.item),
        //                new TreeViewNode("Акты на оплату", IconType.item),
        //                new TreeViewNode("Группы складов", IconType.item),
        //                new TreeViewNode("Шаблоны", IconType.item)
        //            }),
        //           new TreeViewNode("Производство", IconType.folder, new ObservableCollection<TreeViewNode>()
        //            {
        //                new TreeViewNode("Перемещение на цех произодства", IconType.item),
        //                new TreeViewNode("Реестр перемещений в цех производства", IconType.item)
        //            }),
        //           new TreeViewNode("WMS", IconType.folder, new ObservableCollection<TreeViewNode>()
        //            {
        //                new TreeViewNode("Перемещение по заказам", IconType.item)
        //            })
        //};
        private FillTreeViewCommand fillTreeViewCommand;

        public ICommand FillTreeViewCommand
        {
            get
            {
                if (fillTreeViewCommand == null)
                {
                    fillTreeViewCommand = new FillTreeViewCommand(ExecuteFillTreeViewCommand);
                }
                return fillTreeViewCommand;
            }
        }

        public ICommand SelectTreeViewItemCommand
        {
            get
            {
                return null;
            }
        }

        private void ExecuteFillTreeViewCommand(object parm)
        {
            Button btn = parm as Button;
            string name = btn.Name;
            try
            {
                TreeViewContent = Infrastructure.TreeViewData.Data[name];
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }
            OnProperyChanged("TreeViewContent");
        }
    }
}
