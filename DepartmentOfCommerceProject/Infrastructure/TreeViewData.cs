using DepartmentOfCommerceProject.Infrastructure.BusinessObjects;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace DepartmentOfCommerceProject.Infrastructure
{
    static class TreeViewData
    {
        public static Dictionary<string, ObservableCollection<TreeViewNode>> Data { get; set; } = new Dictionary<string, ObservableCollection<TreeViewNode>>()
        {
            { "desktopButton", new ObservableCollection<TreeViewNode>()
                {
                    new TreeViewNode("Продажи", IconType.Folder, new ObservableCollection<TreeViewNode>()
                    {
                        new TreeViewNode("Выписка накладных", IconType.Item)
                        {
                            CommandParameter = "statementsOfWaybills"
                        }
                    }),
                 new TreeViewNode("Розничная торговля", IconType.Folder, new ObservableCollection<TreeViewNode>()
                    {
                        new TreeViewNode("Кассовые операции", IconType.Item) { CommandParameter = "cashboxOperations" },
                        new TreeViewNode("POS", IconType.Item) { CommandParameter = "POS" },
                        new TreeViewNode("Печать ценников ТСД", IconType.Item) { CommandParameter = "priceTagPrint" },
                        new TreeViewNode("Обработка Z-отчетов", IconType.Item) { CommandParameter = "zPeportsProcessing" },
                        new TreeViewNode("Переоценка", IconType.Item) { CommandParameter = "reassessment" },
                        new TreeViewNode("Подарочные сертификаты", IconType.Item) { CommandParameter = "giftCertificates" },
                        new TreeViewNode("Выписка подарочных сертификатов", IconType.Item) { CommandParameter = "issuingGiftCertificates" }
                    }),
                 new TreeViewNode("Закупка", IconType.Folder, new ObservableCollection<TreeViewNode>()
                    {
                        new TreeViewNode("Заказы по потребностям", IconType.Item) { CommandParameter = "requirementsOrders" },
                        new TreeViewNode("Графики заказов", IconType.Item) { CommandParameter = "orderCharts" },
                        new TreeViewNode("Заказы по графику", IconType.Item) { CommandParameter = "scheduledOrders" },
                        new TreeViewNode("Приемка по заказам", IconType.Item) { CommandParameter = "orderAcceptance" },
                        new TreeViewNode("Обновление розничных цен", IconType.Item) { CommandParameter = "retailPriceUpdate" }
                    }),
                 new TreeViewNode("Цены", IconType.Folder, new ObservableCollection<TreeViewNode>()
                    {
                        new TreeViewNode("Управление ценами", IconType.Item) { CommandParameter = "priceManagement" },
                        new TreeViewNode("Текущие цены", IconType.Item) { CommandParameter = "currentPrices" },
                        new TreeViewNode("Розничные цены", IconType.Item) { CommandParameter = "retailPrices" }
                    }),
                  new TreeViewNode("Задолженности", IconType.Folder, new ObservableCollection<TreeViewNode>()
                    {
                        new TreeViewNode("Управление задолженностями", IconType.Item) { CommandParameter = "debtManagement" },
                        new TreeViewNode("Разнесение документов", IconType.Item) { CommandParameter = "spacingDocuments" },
                        new TreeViewNode("Неоплаченные документы", IconType.Item) { CommandParameter = "notPayedDocuments" }
                    }),
                   new TreeViewNode("Маркетинг", IconType.Folder, new ObservableCollection<TreeViewNode>()
                    {
                        new TreeViewNode("Договоры маркетинга", IconType.Item) { CommandParameter = "marketingContracts" },
                        new TreeViewNode("Акты на оплату", IconType.Item) { CommandParameter = "actsOfPayment" },
                        new TreeViewNode("Группы складов", IconType.Item) { CommandParameter = "warehouseGroups" },
                        new TreeViewNode("Шаблоны", IconType.Item) { CommandParameter = "patterns" }
                    }),
                   new TreeViewNode("Производство", IconType.Folder, new ObservableCollection<TreeViewNode>()
                    {
                        new TreeViewNode("Перемещение на цех произодства", IconType.Item),
                        new TreeViewNode("Реестр перемещений в цех производства", IconType.Item)
                    }),
                   new TreeViewNode("WMS", IconType.Folder, new ObservableCollection<TreeViewNode>()
                    {
                        new TreeViewNode("Перемещение по заказам", IconType.Item)
                    })
                }
            },
            { "directoryButton", new ObservableCollection<TreeViewNode>()
                {
                  new TreeViewNode("Сотрудники", IconType.Item),
                  new TreeViewNode("Организации", IconType.Item),
                    new TreeViewNode("Товар", IconType.Folder, new ObservableCollection<TreeViewNode>()
                    {
                        new TreeViewNode("Товары", IconType.Item),
                        new TreeViewNode("Товарные группы", IconType.Item),
                        new TreeViewNode("Еденицы измерений", IconType.Item),
                        new TreeViewNode("Типы дополнительных групп", IconType.Item),
                        new TreeViewNode("Дополнительные группы", IconType.Item),
                        new TreeViewNode("Настройка атрибутов", IconType.Item),
                        new TreeViewNode("Атрибуты товаров", IconType.Item),
                        new TreeViewNode("Списки SKU", IconType.Item),
                        new TreeViewNode("Бренды", IconType.Item)
                    }),
                    new TreeViewNode("Региональные параметры", IconType.Folder, new ObservableCollection<TreeViewNode>()
                    {
                        new TreeViewNode("Языки", IconType.Item),
                        new TreeViewNode("Перевод", IconType.Item),
                        new TreeViewNode("Словари", IconType.Item),
                        new TreeViewNode("Страны", IconType.Item),
                        new TreeViewNode("Выходные дни", IconType.Item)
                    }),
                    new TreeViewNode("Шаблоны", IconType.Folder, new ObservableCollection<TreeViewNode>()
                    {
                        new TreeViewNode("Шаблоны Excel", IconType.Item),
                        new TreeViewNode("Шаблоны Word", IconType.Item)
                    }),
                    new TreeViewNode("Валюты и курсы", IconType.Folder, new ObservableCollection<TreeViewNode>()
                    {
                        new TreeViewNode("Валюты", IconType.Item),
                        new TreeViewNode("Курсы валют", IconType.Item)
                    }),
                     new TreeViewNode("Нумераторы", IconType.Item),
                     new TreeViewNode("Тип подакции", IconType.Item),
                     new TreeViewNode("Тип промо", IconType.Item)
                }
            },
            { "procurementButton", new ObservableCollection<TreeViewNode>()
                {
                    new TreeViewNode("Закупки", IconType.Folder, new ObservableCollection<TreeViewNode>()
                    {
                        new TreeViewNode("Заказы", IconType.Item),
                        new TreeViewNode("Параметры автозаказа", IconType.Item),
                        new TreeViewNode("Накладные", IconType.Item),
                        new TreeViewNode("Акты расхождений", IconType.Item)
                    }),
                    new TreeViewNode("Возвраты", IconType.Folder, new ObservableCollection<TreeViewNode>()
                    {
                        new TreeViewNode("Заказы", IconType.Item),
                        new TreeViewNode("Накладные", IconType.Item),
                        new TreeViewNode("Акты расхождений", IconType.Item)
                    }),
                    new TreeViewNode("Справочники", IconType.Folder, new ObservableCollection<TreeViewNode>()
                    {
                        new TreeViewNode("Операции", IconType.Item)
                    }),
                    new TreeViewNode("Отчеты", IconType.Folder, new ObservableCollection<TreeViewNode>()
                    {
                        new TreeViewNode("Регистр поступлений", IconType.Item),
                        new TreeViewNode("Исполнение заявок", IconType.Item),
                        new TreeViewNode("Отчет по поступлениям", IconType.Item),
                        new TreeViewNode("Поступления по неделям", IconType.Item)
                    })
                }
            }
        };
    }
}