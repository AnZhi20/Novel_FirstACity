using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace FirstACity
{
    /// <summary>
    /// 预设数据管理器 - 负责处理仓库物品预设和配方蓝图预设的逻辑
    /// </summary>
    public static class PresetDataManager
    {
        // 预设物品数据结构
        public struct PresetItem
        {
            public string Name;
            public int Level;
            public int InitialQuantity;
            public string Description;
        }

        // 预设蓝图数据结构
        public struct PresetBlueprint
        {
            public string Name;
            public int Level;
            public string ConsumedMaterials;
            public string ProducedMaterials;
            public string Description;
        }

        /// <summary>
        /// 获取所有预设物品列表
        /// </summary>
        public static List<PresetItem> GetPresetItems()
        {
            return new List<PresetItem>
            {
                // 0级矿物
                new PresetItem { Name = "石矿", Level = 0, InitialQuantity = 0, Description = "基础矿物" },
                new PresetItem { Name = "煤矿", Level = 0, InitialQuantity = 0, Description = "基础矿物" },
                new PresetItem { Name = "铜矿", Level = 0, InitialQuantity = 0, Description = "基础矿物" },
                new PresetItem { Name = "铁矿", Level = 0, InitialQuantity = 0, Description = "基础矿物" },
                new PresetItem { Name = "硅矿", Level = 0, InitialQuantity = 0, Description = "基础矿物" },
                new PresetItem { Name = "钛矿", Level = 0, InitialQuantity = 0, Description = "基础矿物" },
                new PresetItem { Name = "银矿", Level = 0, InitialQuantity = 0, Description = "基础矿物" },
                new PresetItem { Name = "金矿", Level = 0, InitialQuantity = 0, Description = "基础矿物" },
                
                // 1级加工品
                new PresetItem { Name = "石料", Level = 1, InitialQuantity = 0, Description = "基础加工品" },
                new PresetItem { Name = "可燃煤", Level = 1, InitialQuantity = 0, Description = "基础加工品" },
                new PresetItem { Name = "铜锭", Level = 1, InitialQuantity = 0, Description = "基础加工品" },
                new PresetItem { Name = "铁锭", Level = 1, InitialQuantity = 0, Description = "基础加工品" },
                new PresetItem { Name = "硅晶体", Level = 1, InitialQuantity = 0, Description = "基础加工品" },
                new PresetItem { Name = "钛锭", Level = 1, InitialQuantity = 0, Description = "基础加工品" },
                new PresetItem { Name = "银锭", Level = 1, InitialQuantity = 0, Description = "基础加工品" },
                new PresetItem { Name = "金锭", Level = 1, InitialQuantity = 0, Description = "基础加工品" }
            };
        }

        /// <summary>
        /// 获取所有预设蓝图列表
        /// </summary>
        public static List<PresetBlueprint> GetPresetBlueprints()
        {
            return new List<PresetBlueprint>
            {
                new PresetBlueprint 
                { 
                    Name = "石料加工", 
                    Level = 1, 
                    ConsumedMaterials = "石矿x5", 
                    ProducedMaterials = "石料x1", 
                    Description = "将5个石矿加工成1个石料"
                },
                new PresetBlueprint 
                { 
                    Name = "可燃煤加工", 
                    Level = 1, 
                    ConsumedMaterials = "煤矿x5", 
                    ProducedMaterials = "可燃煤x1", 
                    Description = "将5个煤矿加工成1个可燃煤"
                },
                new PresetBlueprint 
                { 
                    Name = "铜锭加工", 
                    Level = 1, 
                    ConsumedMaterials = "铜矿x5", 
                    ProducedMaterials = "铜锭x1", 
                    Description = "将5个铜矿加工成1个铜锭"
                },
                new PresetBlueprint 
                { 
                    Name = "铁锭加工", 
                    Level = 1, 
                    ConsumedMaterials = "铁矿x5", 
                    ProducedMaterials = "铁锭x1", 
                    Description = "将5个铁矿加工成1个铁锭"
                },
                new PresetBlueprint 
                { 
                    Name = "硅晶体加工", 
                    Level = 1, 
                    ConsumedMaterials = "硅矿x5", 
                    ProducedMaterials = "硅晶体x1", 
                    Description = "将5个硅矿加工成1个硅晶体"
                },
                new PresetBlueprint 
                { 
                    Name = "钛锭加工", 
                    Level = 1, 
                    ConsumedMaterials = "钛矿x5", 
                    ProducedMaterials = "钛锭x1", 
                    Description = "将5个钛矿加工成1个钛锭"
                },
                new PresetBlueprint 
                { 
                    Name = "银锭加工", 
                    Level = 1, 
                    ConsumedMaterials = "银矿x5", 
                    ProducedMaterials = "银锭x1", 
                    Description = "将5个银矿加工成1个银锭"
                },
                new PresetBlueprint 
                { 
                    Name = "金锭加工", 
                    Level = 1, 
                    ConsumedMaterials = "金矿x5", 
                    ProducedMaterials = "金锭x1", 
                    Description = "将5个金矿加工成1个金锭"
                }
            };
        }

        /// <summary>
        /// 初始化仓库物品
        /// </summary>
        /// <param name="warehouseDataGridView">仓库DataGridView控件</param>
        public static void InitializeWarehouseItems(DataGridView warehouseDataGridView)
        {
            if (warehouseDataGridView == null)
                return;

            // 清空现有数据
            warehouseDataGridView.Rows.Clear();

            // 添加预设物品
            foreach (var item in GetPresetItems())
            {
                warehouseDataGridView.Rows.Add(
                    item.Level.ToString(),
                    item.Name,
                    item.InitialQuantity.ToString(),
                    item.Description
                );
            }
        }

        /// <summary>
        /// 初始化配方蓝图
        /// </summary>
        /// <param name="blueprintDataGridView">蓝图DataGridView控件</param>
        public static void InitializeBlueprints(DataGridView blueprintDataGridView)
        {
            if (blueprintDataGridView == null)
                return;

            // 清空现有数据
            blueprintDataGridView.Rows.Clear();

            // 添加预设蓝图
            foreach (var blueprint in GetPresetBlueprints())
            {
                blueprintDataGridView.Rows.Add(
                    blueprint.Level.ToString(),
                    blueprint.Name,
                    blueprint.ConsumedMaterials,
                    blueprint.ProducedMaterials,
                    blueprint.Description,
                    false // usedColumn，默认为未使用
                );
            }
        }
    }
}