using System;
using System.Collections.Generic;

namespace CaoThiPhuongVy_21k4080064.Services
{
    public class CategoryService
    {
        // Sự kiện để thông báo khi danh mục thay đổi
        public event Action? OnChange;

        // Danh sách các danh mục
        private List<string> categories = new() { "Work", "Personal", "Shopping" };

        // Phương thức để lấy danh sách các danh mục
        public List<string> GetCategories()
        {
            return categories;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddSingleton<CategoryService>(); // Thêm dòng này
        }

        // Phương thức để thêm danh mục mới
        public void AddCategory(string category)
        {
            if (!string.IsNullOrWhiteSpace(category) && !categories.Contains(category))
            {
                categories.Add(category);
                NotifyStateChanged();
            }
        }

        // Phương thức để cập nhật danh mục
        public void UpdateCategory(string oldCategory, string newCategory)
        {
            var index = categories.IndexOf(oldCategory);
            if (index != -1 && !string.IsNullOrWhiteSpace(newCategory))
            {
                categories[index] = newCategory;
                NotifyStateChanged();
            }
        }

        // Phương thức để xóa danh mục
        public void DeleteCategory(string category)
        {
            categories.Remove(category);
            NotifyStateChanged();
        }

        // Phương thức để thông báo thay đổi
        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
