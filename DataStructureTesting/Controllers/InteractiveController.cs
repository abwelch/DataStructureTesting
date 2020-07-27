using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace RunTimeAnalyzer.Controllers
{
    public class InteractiveController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SinglyLinkedList()
        {
            return View();
        }

        public IActionResult DoublyLinkedList()
        {
            return View();
        }

        public IActionResult Stack()
        {
            return View();
        }

        public IActionResult Queue()
        {
            return View();
        }

        public IActionResult CircularQueue()
        {
            return View();
        }

        public IActionResult BinaryTree()
        {
            return View();
        }

        public IActionResult BinarySearchTree()
        {
            return View();
        }
    }
}