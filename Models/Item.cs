using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace HybridiProjekti.Models
{   // Reprsents a single item in the shopping list
    public record Item(int Id, string Name, string ImagePath, int Quantity, string Category);

}


