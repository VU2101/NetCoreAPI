using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FirstWebMVC.Data;
using FirstWebMVC.Models;
using FirstWebMVC.Models.Process;
using OfficeOpenXml;
using X.PagedList;
using X.PagedList.Extensions;

namespace FirstWebMVC.Controllers
{
    public class PersonController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PersonController(ApplicationDbContext context)
        {
            _context = context;
        }
         private ExcelProcess _excelProcess = new ExcelProcess();
          public async Task<IActionResult> Index(int? page, int? PageSize)
        {
            ViewBag.PageSize = new List<SelectListItem>()
            {
                new SelectListItem(){ Value="3", Text="3"},
                new SelectListItem(){ Value="5", Text="5"},
                new SelectListItem(){ Value="10", Text="10"},
                new SelectListItem(){ Value="15", Text="15"},
                new SelectListItem(){ Value="25", Text="25"},
                new SelectListItem(){ Value="50", Text="50"},
            };
            int pagesize = (PageSize ?? 3);
            ViewBag.psize = pagesize;
            var model = _context.Person.ToList().ToPagedList(page ?? 1, pagesize);
            return View(model);
        }


        // GET: Person
        //public async Task<IActionResult> Index()
        //{
          //  return View(await _context.Person.ToListAsync());
        //}

        // GET: Person/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var person = await _context.Person
                .FirstOrDefaultAsync(m => m.PersonID == id);
            if (person == null)
            {
                return NotFound();
            }

            return View(person);
        }

        // GET: Person/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Person/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PersonID,Hoten,Quequan")] Person person)
        {
            if (ModelState.IsValid)
            {
                _context.Add(person);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(person);
        }

        // GET: Person/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var person = await _context.Person.FindAsync(id);
            if (person == null)
            {
                return NotFound();
            }
            return View(person);
        }

        // POST: Person/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("PersonID,Hoten,Quequan")] Person person)
        {
            if (id != person.PersonID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(person);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonExists(person.PersonID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(person);
        }

        // GET: Person/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var person = await _context.Person
                .FirstOrDefaultAsync(m => m.PersonID == id);
            if (person == null)
            {
                return NotFound();
            }

            return View(person);
        }

        // POST: Person/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var person = await _context.Person.FindAsync(id);
            if (person != null)
            {
                _context.Person.Remove(person);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersonExists(string id)
        {
            return _context.Person.Any(e => e.PersonID == id);
        }
        public IActionResult Upload()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            if (file!=null)
                {
                    string fileExtension = Path.GetExtension(file.FileName);
                    if (fileExtension != ".xls" && fileExtension != ".xlsx")
                    {
                        ModelState.AddModelError("", "Please choose excel file to upload!");
                    }
                    else
                    {
                        //rename file when upload to server
                        var fileName = DateTime.Now.ToShortTimeString() + fileExtension;
                        var filePath = Path.Combine(Directory.GetCurrentDirectory() + "/Uploads/Excels", "File" + DateTime.Now.Day + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Millisecond + fileExtension);
                        var fileLocation = new FileInfo(filePath).ToString();
                        if (file.Length > 0)
                        {
                            using (var stream = new FileStream(filePath, FileMode.Create))
                            {
                                //save file to server
                                await file.CopyToAsync(stream);
                                //read data from file and write to database
                                var dt = _excelProcess.ExcelToDataTable(fileLocation);
                                for(int i = 0; i < dt.Rows.Count; i++)
                                {
                                    var ps = new Person();
                                    ps.PersonID = dt.Rows[i][0].ToString();
                                    ps.Hoten = dt.Rows[i][1].ToString();
                                    ps.Quequan = dt.Rows[i][2].ToString();
                                    _context.Add(ps);
                                }
                                await _context.SaveChangesAsync();
                                return RedirectToAction(nameof(Index));
                            }
                        }
                    }
                }
            
            return View();
    }
     public async Task<IActionResult> DownLoad()
        {
            // Đặt tên cho file khi tải xuống
            var fileName = "Person.xlsx";

            // Sử dụng "using" để đảm bảo ExcelPackage được giải phóng tài nguyên sau khi sử dụng
            using (var excelPackage = new ExcelPackage())
            {
                var worksheet = excelPackage.Workbook.Worksheets.Add("Sheet 1");

                // Đặt tiêu đề cho các cột
                worksheet.Cells["A1"].Value = "PersonID";
                worksheet.Cells["B1"].Value = "Hoten";
                worksheet.Cells["C1"].Value = "Quequan";

                // Lấy danh sách Person
                var personList = _context.Person.ToList();

                worksheet.Cells["A2"].LoadFromCollection(personList, false, OfficeOpenXml.Table.TableStyles.Medium2);

                var stream = new MemoryStream(await excelPackage.GetAsByteArrayAsync());

                // Tải file xuống
                return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);
            }
        }}
}

    
    

