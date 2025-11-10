using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace FirstACity
{
    /// <summary>
    /// 保存和读取管理器 - 负责处理所有标签页数据的保存和读取
    /// </summary>
    public class SaveAndRead
    {
        // 数据模型定义
        public class SaveData
        {
            public List<WarehouseItem> WarehouseItems { get; set; } = new List<WarehouseItem>();
            public List<BlueprintItem> BlueprintItems { get; set; } = new List<BlueprintItem>();
            public List<DungeonItem> DungeonItems { get; set; } = new List<DungeonItem>();
            public List<EventItem> EventItems { get; set; } = new List<EventItem>();
            public DateTime SaveTime { get; set; } = DateTime.Now;
        }

        public class WarehouseItem
        {
            public string Level { get; set; }
            public string Name { get; set; }
            public string Quantity { get; set; }
            public string Description { get; set; }
        }

        public class BlueprintItem
        {
            public string Level { get; set; }
            public string Name { get; set; }
            public string ConsumedMaterials { get; set; }
            public string ProducedMaterials { get; set; }
            public string Description { get; set; }
            public string Used { get; set; }
        }

        public class DungeonItem
        {
            public string Level { get; set; }
            public string Name { get; set; }
            public string ConsumedItems { get; set; }
            public string ObtainedItems { get; set; }
            public string Description { get; set; }
        }

        public class EventItem
        {
            public string Chapter { get; set; }
            public string Item { get; set; }
            public string Talent { get; set; }
            public string Description { get; set; }
            public string BlueprintUsed { get; set; }
            public string DungeonParticipated { get; set; }
        }

        /// <summary>
        /// 保存所有标签页数据到文件
        /// </summary>
        /// <param name="filePath">文件路径</param>
        /// <param name="warehouseGrid">仓库数据表格</param>
        /// <param name="blueprintGrid">蓝图数据表格</param>
        /// <param name="dungeonGrid">副本数据表格</param>
        /// <param name="eventGrid">事件数据表格</param>
        /// <returns>是否保存成功</returns>
        public bool SaveDataToFile(string filePath, DataGridView warehouseGrid, DataGridView blueprintGrid, DataGridView dungeonGrid, DataGridView eventGrid)
        {
            try
            {
                SaveData data = new SaveData();

                // 保存仓库数据
                if (warehouseGrid != null)
                {
                    foreach (DataGridViewRow row in warehouseGrid.Rows)
                    {
                        if (!row.IsNewRow && row.Cells.Count >= 4)
                        {
                            data.WarehouseItems.Add(new WarehouseItem
                            {
                                Level = row.Cells[0].Value?.ToString() ?? "",
                                Name = row.Cells[1].Value?.ToString() ?? "",
                                Quantity = row.Cells[2].Value?.ToString() ?? "",
                                Description = row.Cells[3].Value?.ToString() ?? ""
                            });
                        }
                    }
                }

                // 保存蓝图数据
                if (blueprintGrid != null)
                {
                    foreach (DataGridViewRow row in blueprintGrid.Rows)
                    {
                        if (!row.IsNewRow && row.Cells.Count >= 6)
                        {
                            data.BlueprintItems.Add(new BlueprintItem
                            {
                                Level = row.Cells[0].Value?.ToString() ?? "",
                                Name = row.Cells[1].Value?.ToString() ?? "",
                                ConsumedMaterials = row.Cells[2].Value?.ToString() ?? "",
                                ProducedMaterials = row.Cells[3].Value?.ToString() ?? "",
                                Description = row.Cells[4].Value?.ToString() ?? "",
                                Used = row.Cells[5].Value?.ToString() ?? ""
                            });
                        }
                    }
                }

                // 保存副本数据
                if (dungeonGrid != null)
                {
                    foreach (DataGridViewRow row in dungeonGrid.Rows)
                    {
                        if (!row.IsNewRow && row.Cells.Count >= 5)
                        {
                            data.DungeonItems.Add(new DungeonItem
                            {
                                Level = row.Cells[0].Value?.ToString() ?? "",
                                Name = row.Cells[1].Value?.ToString() ?? "",
                                ConsumedItems = row.Cells[2].Value?.ToString() ?? "",
                                ObtainedItems = row.Cells[3].Value?.ToString() ?? "",
                                Description = row.Cells[4].Value?.ToString() ?? ""
                            });
                        }
                    }
                }

                // 保存事件数据
                if (eventGrid != null)
                {
                    foreach (DataGridViewRow row in eventGrid.Rows)
                    {
                        if (!row.IsNewRow && row.Cells.Count >= 6)
                        {
                            data.EventItems.Add(new EventItem
                            {
                                Chapter = row.Cells[0].Value?.ToString() ?? "",
                                Item = row.Cells[1].Value?.ToString() ?? "",
                                Talent = row.Cells[2].Value?.ToString() ?? "",
                                Description = row.Cells[3].Value?.ToString() ?? "",
                                BlueprintUsed = row.Cells[4].Value?.ToString() ?? "",
                                DungeonParticipated = row.Cells[5].Value?.ToString() ?? ""
                            });
                        }
                    }
                }

                // 序列化并保存到文件
                string jsonString = JsonConvert.SerializeObject(data, Formatting.Indented);
                File.WriteAllText(filePath, jsonString);

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"保存数据时出错: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// 从文件读取所有标签页数据
        /// </summary>
        /// <param name="filePath">文件路径</param>
        /// <param name="warehouseGrid">仓库数据表格</param>
        /// <param name="blueprintGrid">蓝图数据表格</param>
        /// <param name="dungeonGrid">副本数据表格</param>
        /// <param name="eventGrid">事件数据表格</param>
        /// <returns>是否读取成功</returns>
        public bool ReadDataFromFile(string filePath, DataGridView warehouseGrid, DataGridView blueprintGrid, DataGridView dungeonGrid, DataGridView eventGrid)
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    MessageBox.Show("文件不存在", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                string jsonString = File.ReadAllText(filePath);
                SaveData data = JsonConvert.DeserializeObject<SaveData>(jsonString);

                if (data == null)
                {
                    MessageBox.Show("文件格式错误或数据为空", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                // 读取仓库数据
                if (warehouseGrid != null)
                {
                    warehouseGrid.Rows.Clear();
                    foreach (var item in data.WarehouseItems)
                    {
                        warehouseGrid.Rows.Add(item.Level, item.Name, item.Quantity, item.Description);
                    }
                }

                // 读取蓝图数据
                if (blueprintGrid != null)
                {
                    blueprintGrid.Rows.Clear();
                    foreach (var item in data.BlueprintItems)
                    {
                        blueprintGrid.Rows.Add(
                            item.Level, 
                            item.Name, 
                            item.ConsumedMaterials, 
                            item.ProducedMaterials, 
                            item.Description, 
                            string.IsNullOrEmpty(item.Used) ? false : bool.Parse(item.Used)
                        );
                    }
                }

                // 读取副本数据
                if (dungeonGrid != null)
                {
                    dungeonGrid.Rows.Clear();
                    foreach (var item in data.DungeonItems)
                    {
                        dungeonGrid.Rows.Add(item.Level, item.Name, item.ConsumedItems, item.ObtainedItems, item.Description);
                    }
                }

                // 读取事件数据
                if (eventGrid != null)
                {
                    eventGrid.Rows.Clear();
                    foreach (var item in data.EventItems)
                    {
                        eventGrid.Rows.Add(item.Chapter, item.Item, item.Talent, item.Description, item.BlueprintUsed, item.DungeonParticipated);
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"读取数据时出错: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// 检查文件是否为有效的保存文件
        /// </summary>
        /// <param name="filePath">文件路径</param>
        /// <returns>是否有效</returns>
        public bool IsValidSaveFile(string filePath)
        {
            try
            {
                if (!File.Exists(filePath))
                    return false;

                string jsonString = File.ReadAllText(filePath);
                SaveData data = JsonConvert.DeserializeObject<SaveData>(jsonString);
                return data != null;
            }
            catch
            {
                return false;
            }
        }
    }
}
