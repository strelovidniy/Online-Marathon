using Microsoft.AspNetCore.Mvc;
using Sprint_12.Models;

namespace Sprint_12.Controllers
{
    public class TriangleController : Controller
    {
        public ActionResult Info(double side1, double side2, double side3)
        {
            ViewData["Info"] = new Triangle(side1, side2, side3).ShowInfo();
            return View();
        }

        public ActionResult Area(double side1, double side2, double side3)
        {
            ViewData["Area"] = new Triangle(side1, side2, side3).Area;
            return View();
        }

        public ActionResult Perimeter(double side1, double side2, double side3)
        {
            ViewData["Perimeter"] = new Triangle(side1, side2, side3).Perimeter;
            return View();
        }

        public ActionResult IsRightAngled(double side1, double side2, double side3)
        {
            ViewData["IsRightAngled"] = new Triangle(side1, side2, side3).IsRightAngled;
            return View();
        }

        public ActionResult IsEquilateral(double side1, double side2, double side3)
        {
            ViewData["IsEquilateral"] = new Triangle(side1, side2, side3).IsEquilateral;
            return View();
        }

        public ActionResult IsIsosceles(double side1, double side2, double side3)
        {
            ViewData["IsIsosceles"] = new Triangle(side1, side2, side3).IsIsosceles;
            return View();
        }

        public ActionResult AreCongruent(Triangle tr1, Triangle tr2)
        {
            ViewData["AreCongruent"] = TrianglesComparsor.AreCongruent(new Triangle(tr1), new Triangle(tr2));
            return View();
        }

        public ActionResult AreSimilar(Triangle tr1, Triangle tr2)
        {
            ViewData["AreSimilar"] = TrianglesComparsor.AreSimilar(new Triangle(tr1), new Triangle(tr2));
            return View();
        }

        public ActionResult GreatestByPerimeter(Triangle[] tr)
        {
            ViewData["GreatestByPerimeter"] = new TrianglesComparsor(tr).GreatestByPerimeter.ShowInfo();
            return View();
        }

        public ActionResult GreatestByArea(Triangle[] tr)
        {
            ViewData["GreatestByArea"] = new TrianglesComparsor(tr).GreatestByArea.ShowInfo();
            return View();
        }

        public ActionResult PairwiseNonSimilar(params Triangle[] tr)
        {
            ViewData["PairwiseNonSimilar"] = new TrianglesComparsor(tr).NonSimilarTriangles();
            return View();
        }
    }
}
