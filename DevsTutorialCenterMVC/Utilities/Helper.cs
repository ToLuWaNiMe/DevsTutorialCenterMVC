﻿using DevsTutorialCenterMVC.Models;

namespace DevsTutorialCenterMVC.Utilities
{
    public static class Helper
    {
        public static PaginatorResponseViewModel<IEnumerable<T>> Paginate<T>(IEnumerable<T> items, int pageNum,
            int pageSize)
        {
            var totalCount = items.Count();
            var totalPages = (int)Math.Ceiling((double)totalCount / pageSize);
            
            if (pageNum <= 0 || pageNum > totalPages)
            {
                pageNum = totalPages;
            }

            var skipAmount = (pageNum - 1) * pageSize;
            var paginatedItems = items.Skip(skipAmount).Take(pageSize).ToList();
            
            return new PaginatorResponseViewModel<IEnumerable<T>>
            {
                PageItems = paginatedItems,
                PageSize = pageSize,
                CurrentPage = pageNum,
                NumberOfPages = totalPages,
                TotalCount = totalCount,
                PreviousPage = pageNum > 1 ? pageNum - 1 : null,
                NextPage = totalPages == pageNum ? null : pageNum + 1
            };
        }

        public static string FormatDate(this DateTime date)
        {
            return date.ToString("yy-MMM-dd ddd");
        }
    }
}