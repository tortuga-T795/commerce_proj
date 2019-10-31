using DepartmentOfCommerceProject.Infrastructure.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;

namespace DepartmentOfCommerceProject.Infrastructure
{
    static class TreeViewData
    {
        public static Dictionary<string, ObservableCollection<TreeViewNode>> Data { get; set; } = new Dictionary<string, ObservableCollection<TreeViewNode>>()
        {
            { "desktopButton", new ObservableCollection<TreeViewNode>()
                {
                    new TreeViewNode("Продажи", IconType.folder, new ObservableCollection<TreeViewNode>()
                    {
                        new TreeViewNode("Выписка накладных", IconType.item)
                    }),
                 new TreeViewNode("Розничная торговля", IconType.folder, new ObservableCollection<TreeViewNode>()
                    {
                        new TreeViewNode("Кассовые операции", IconType.item),
                        new TreeViewNode("POS", IconType.item),
                        new TreeViewNode("Печать ценников ТСД", IconType.item),
                        new TreeViewNode("Обработка Z-отчетов", IconType.item),
                        new TreeViewNode("Переоценка", IconType.item),
                        new TreeViewNode("Подарочные сертификаты", IconType.item),
                        new TreeViewNode("Выписка подарочных сертификатов", IconType.item)
                    }),
                 new TreeViewNode("Закупка", IconType.folder, new ObservableCollection<TreeViewNode>()
                    {
                        new TreeViewNode("Заказы по потребностям", IconType.item),
                        new TreeViewNode("Графики заказов", IconType.item),
                        new TreeViewNode("Заказы по графику", IconType.item),
                        new TreeViewNode("Приемка по заказам", IconType.item),
                        new TreeViewNode("Обновление розничных цен", IconType.item)
                    }),
                 new TreeViewNode("Цены", IconType.folder, new ObservableCollection<TreeViewNode>()
                    {
                        new TreeViewNode("Управление ценами", IconType.item),
                        new TreeViewNode("Текущие цены", IconType.item),
                        new TreeViewNode("Розничные цены", IconType.item)
                    }),
                  new TreeViewNode("Задолженности", IconType.folder, new ObservableCollection<TreeViewNode>()
                    {
                        new TreeViewNode("Управление задолженностями", IconType.item),
                        new TreeViewNode("Разнесение документов", IconType.item),
                        new TreeViewNode("Неоплаченные документы", IconType.item)
                    }),
                   new TreeViewNode("Маркетинг", IconType.folder, new ObservableCollection<TreeViewNode>()
                    {
                        new TreeViewNode("Договоры маркетинга", IconType.item),
                        new TreeViewNode("Акты на оплату", IconType.item),
                        new TreeViewNode("Группы складов", IconType.item),
                        new TreeViewNode("Шаблоны", IconType.item)
                    }),
                   new TreeViewNode("Производство", IconType.folder, new ObservableCollection<TreeViewNode>()
                    {
                        new TreeViewNode("Перемещение на цех произодства", IconType.item),
                        new TreeViewNode("Реестр перемещений в цех производства", IconType.item)
                    }),
                   new TreeViewNode("WMS", IconType.folder, new ObservableCollection<TreeViewNode>()
                    {
                        new TreeViewNode("Перемещение по заказам", IconType.item)
                    })
                }
            },
            { "directoryButton", new ObservableCollection<TreeViewNode>()
                {
                  new TreeViewNode("Сотрудники", IconType.item),
                  new TreeViewNode("Организации", IconType.item),
                    new TreeViewNode("Товар", IconType.folder, new ObservableCollection<TreeViewNode>()
                    {
                        new TreeViewNode("Товары", IconType.item),
                        new TreeViewNode("Товарные группы", IconType.item),
                        new TreeViewNode("Еденицы измерений", IconType.item),
                        new TreeViewNode("Типы дополнительных групп", IconType.item),
                        new TreeViewNode("Дополнительные группы", IconType.item),
                        new TreeViewNode("Настройка атрибутов", IconType.item),
                        new TreeViewNode("Атрибуты товаров", IconType.item),
                        new TreeViewNode("Списки SKU", IconType.item),
                        new TreeViewNode("Бренды", IconType.item)
                    }),
                    new TreeViewNode("Региональные параметры", IconType.folder, new ObservableCollection<TreeViewNode>()
                    {
                        new TreeViewNode("Языки", IconType.item),
                        new TreeViewNode("Перевод", IconType.item),
                        new TreeViewNode("Словари", IconType.item),
                        new TreeViewNode("Страны", IconType.item),
                        new TreeViewNode("Выходные дни", IconType.item)
                    }),
                    new TreeViewNode("Шаблоны", IconType.folder, new ObservableCollection<TreeViewNode>()
                    {
                        new TreeViewNode("Шаблоны Excel", IconType.item),
                        new TreeViewNode("Шаблоны Word", IconType.item)
                    }),
                    new TreeViewNode("Валюты и курсы", IconType.folder, new ObservableCollection<TreeViewNode>()
                    {
                        new TreeViewNode("Валюты", IconType.item),
                        new TreeViewNode("Курсы валют", IconType.item)
                    }),
                     new TreeViewNode("Нумераторы", IconType.item),
                     new TreeViewNode("Тип подакции", IconType.item),
                     new TreeViewNode("Тип промо", IconType.item)
                }
            },
            { "procurementButton", new ObservableCollection<TreeViewNode>()
                {
                    new TreeViewNode("Закупки", IconType.folder, new ObservableCollection<TreeViewNode>()
                    {
                        new TreeViewNode("Заказы", IconType.item),
                        new TreeViewNode("Параметры автозаказа", IconType.item),
                        new TreeViewNode("Накладные", IconType.item),
                        new TreeViewNode("Акты расхождений", IconType.item)
                    }),
                    new TreeViewNode("Возвраты", IconType.folder, new ObservableCollection<TreeViewNode>()
                    {
                        new TreeViewNode("Заказы", IconType.item),
                        new TreeViewNode("Накладные", IconType.item),
                        new TreeViewNode("Акты расхождений", IconType.item)
                    }),
                    new TreeViewNode("Справочники", IconType.folder, new ObservableCollection<TreeViewNode>()
                    {
                        new TreeViewNode("Операции", IconType.item)
                    }),
                    new TreeViewNode("Отчеты", IconType.folder, new ObservableCollection<TreeViewNode>()
                    {
                        new TreeViewNode("Регистр поступлений", IconType.item),
                        new TreeViewNode("Исполнение заявок", IconType.item),
                        new TreeViewNode("Отчет по поступлениям", IconType.item),
                        new TreeViewNode("Поступления по неделям", IconType.item)
                    })
                }
            }
        };
    }
}