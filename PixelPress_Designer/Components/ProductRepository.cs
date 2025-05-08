using DotNetNuke.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PixelPress_DesignerPixelPress_Designer.Components
{
    public class ProductRepository
    {
        public string GetProductImage(string bvin)
        {
            using (var context = DataContext.Instance())
            {
                return context.ExecuteScalar<string>(System.Data.CommandType.Text,
                    "SELECT ImageFileMedium FROM hcc_Product WHERE bvin = '87D8E057-B5E1-4D34-A185-37A61E74B7D0'");
            }
        }
    }
}
