using System.Data.Entity;
using System.Threading.Tasks;
using System.Net;
using System.Web.Mvc;
using ExceliaMvc.DAL;
using ExceliaMvc.Models;
using System.Linq;

namespace ExceliaMvc.Controllers
{
    public class DirectionController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Direction
        public async Task<ActionResult> Index(FilterViewModel filter)
        {
            if (filter.Direction == null || filter.Date == null)
            {
                return View(await db.Directions.ToListAsync());
            }
            var query = from n in db.Directions
                        where n.Description.Contains(filter.Direction)
                        select n;

            if (filter.Date.HasValue)
            {
                query = query.Where(r => r.Created == filter.Date.Value);
            }


            return View(await query.ToListAsync());
        }

        // GET: Direction/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Direction direction = await db.Directions.FindAsync(id);
            if (direction == null)
            {
                return HttpNotFound();
            }
            return View(direction);
        }

        // GET: Direction/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Direction/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "DirectionId,Description,Latitud,Longitud,UserCreated,Created,UserUpdated,Updated")] Direction direction)
        {
            if (ModelState.IsValid)
            {
                db.Directions.Add(direction);
                await db.SaveChangesAsync();

                return new EmptyResult();
            }

            return View(direction);
        }

        // GET: Direction/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Direction direction = await db.Directions.FindAsync(id);
            if (direction == null)
            {
                return HttpNotFound();
            }
            return View(direction);
        }

        // POST: Direction/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "DirectionId,Description,Latitud,Longitud,UserCreated,Created,UserUpdated,Updated")] Direction direction)
        {
            if (ModelState.IsValid)
            {
                db.Entry(direction).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(direction);
        }

        // GET: Direction/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Direction direction = await db.Directions.FindAsync(id);
            if (direction == null)
            {
                return HttpNotFound();
            }
            return View(direction);
        }

        // POST: Direction/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Direction direction = await db.Directions.FindAsync(id);
            db.Directions.Remove(direction);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
