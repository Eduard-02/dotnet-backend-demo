using DotnetBackendDemo.Api.Contracts.Companies;
using DotnetBackendDemo.Api.Domain.Entities;
using DotnetBackendDemo.Api.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DotnetBackendDemo.Api.Controllers;

[ApiController]
[Route("companies")]
public class CompaniesController : ControllerBase
{
	private readonly AppDbContext _db;

	public CompaniesController(AppDbContext db)
	{
		_db = db;
	}

	// POST /companies
	[HttpPost]
	public async Task<ActionResult<CompanyResponse>> Create(CreateCompanyRequest request)
	{
		var company = new Company
		{
			Name = request.Name.Trim(),
			BusinessId = string.IsNullOrWhiteSpace(request.BusinessId) ? null : request.BusinessId.Trim()
		};

		_db.Companies.Add(company);
		await _db.SaveChangesAsync();

		return CreatedAtAction(nameof(GetById), new { id = company.Id }, new CompanyResponse
		{
			Id = company.Id,
			Name = company.Name,
			BusinessId = company.BusinessId,
			CreatedAtUtc = company.CreatedAtUtc
		});
	}

	// GET /companies/{id}
	[HttpGet("{id:guid}")]
	public async Task<ActionResult<CompanyResponse>> GetById(Guid id)
	{
		var company = await _db.Companies.AsNoTracking()
			.FirstOrDefaultAsync(c => c.Id == id);

		if (company is null)
			return NotFound();

		return new CompanyResponse
		{
			Id = company.Id,
			Name = company.Name,
			BusinessId = company.BusinessId,
			CreatedAtUtc = company.CreatedAtUtc
		};
	}
}