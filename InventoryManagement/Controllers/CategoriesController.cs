using Azure;
using InventoryManagement.Core.Interfaces;
using InventoryManagement.Core.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using System;

namespace InventoryManagement.API.Controllers;

[ApiController]
[Route("[controller]")]
public class Categories : ControllerBase
{
    public IUnitOfWork _unitOfWork;
    public Categories(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [HttpGet(nameof(GetAllCategories))]
    public IActionResult GetAllCategories()
    {
        var Categories = (_unitOfWork.Categories.GetAll());
        if (!Categories.Any())
        {
            return NoContent();
        }
        return Ok(Categories);
    }

    [HttpGet(nameof(GetCategoryById))]
    public IActionResult GetCategoryById(int id)
    {
        var category = _unitOfWork.Categories.GetById(id);
        if (category == null)
        {
            return NotFound();
        }
        return Ok(category);
    }

    [HttpPost(nameof(InsertpCategory))]
    public IActionResult InsertpCategory(Category category)
    {
        if (category == null)
        {
            return BadRequest();
        }
        else
        {
            _unitOfWork.Categories.Insert(category);
            _unitOfWork.SaveChanges();
            return Ok("category successfully added");
        }
    }

    [HttpDelete(nameof(DeletepCategory))]
    public IActionResult DeletepCategory(Category Category)
    {
        if (Category == null)
        {
            return NotFound();
        }
        else
        {
            _unitOfWork.Categories.Delete(Category);
            _unitOfWork.SaveChanges();
            return (Ok("category successfully deleted"));
        }
    }

    [HttpPut(nameof(UpdateCategory))]
    public IActionResult UpdateCategory(Category category)
    {
        var existingCategory = _unitOfWork.Categories.GetById(category.Id);

        if (existingCategory == null)
        {
            return NotFound();
        }
        _unitOfWork.Categories.Update(category);
        _unitOfWork.SaveChanges();
        return Ok("category successfully updated");
    }

}
