using CodeFirstEFdemo;
using CodeFirstEFdemo.Data;
using CodeFirstEFdemo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

var context = new AppDbContext();

////create a new category

//var electronics = new Category { Name = "Electronics" };
//context.Category.Add(electronics);
//await context.SaveChangesAsync();
//context.Products.AddRange(new Product { Name = "Laptop", Price = 1000.00M, category = electronics },
//    new Product { Name = "Mouse", Price = 500.00M, category = electronics });
//await context.SaveChangesAsync();

////update command
//var laptop= await context.Products.FirstAsync(p => p.Name == "Laptop");
//laptop.Price=7899.67M;
//await context.SaveChangesAsync();

////delete command
//context.Products.Remove(laptop);
//context.SaveChanges();

//Query auther with Courses
//var authors = await context.Authors
//    .Include(x => x.Courses)
//    .ToListAsync();
//foreach(var auth in authors)
//{
//    Console.WriteLine($"Auther: {auth.Name}");
//    foreach(var course in auth.Courses)
//    {
//        Console.WriteLine($"Course: {course.Title}--CourseDescription: {course.Description}--{course.level}");
//    }
//}
//var newProduct = new Product { Name = "Smartphone", Price = 1500.00M, CategoryId = 3 };
//IProductRepository obj= new ProductRepository(context);
//await obj.AddAsync(newProduct);

//var toupdate = await obj.GetByIdAsync(newProduct.Id);
//if (toupdate != null)
//{
//    toupdate.Price = 1200.00M;
//    toupdate.Name = "Normal Phone";
//    await obj.UpdateAsync(toupdate);
//    Console.WriteLine($"Updated: {toupdate.Name}--{toupdate.Price}");
   
//}

//var producttofetch = await obj.GetByIdAsync(7);

//if (producttofetch != null)
//{
//    producttofetch.Price = 555.67M;
//    producttofetch.Name = "normalphone2";
//    await obj.UpdateAsync(producttofetch);
//    Console.WriteLine($"Updated : {producttofetch.Name}--{producttofetch.Price}");
//}

//await obj.DeleteAsync(7);

IProductRepository obj2= new ProductRepository2(context);
//var newProd=new Product { Name = "Tablet", Price = 2000.00M, CategoryId = 3 };
//await obj2.AddAsync(newProd);
var toUpdate = await obj2.GetByIdAsync(9);
if (toUpdate != null)
{
    toUpdate.Price = 1800.00M;
    toUpdate.Name = "Normal Tablet";
    await obj2.UpdateAsync(toUpdate);
    Console.WriteLine($"Updated: {toUpdate.Name}--{toUpdate.Price}");
}