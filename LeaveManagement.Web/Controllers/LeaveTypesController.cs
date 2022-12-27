using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LeaveManagement.Web.Data;
using AutoMapper;
using LeaveManagement.Web.Models;
using LeaveManagement.Web.Contracts;
using LeaveManagement.Web.Repositories;

namespace LeaveManagement.Web.Controllers
{
    public class LeaveTypesController : Controller
    {
        //private readonly ApplicationDbContext _context; inject repon instead of db
        private readonly ILeaveTypeRepository leaveTypeRepository;
        private readonly IMapper _mapper;

        public LeaveTypesController(ILeaveTypeRepository leaveTypeRepository, IMapper mapper) //mapper and dbcontext injected
        {
            //_context = context;
            leaveTypeRepository= leaveTypeRepository;
            _mapper = mapper;
        }

        // GET: LeaveTypes
        public async Task<IActionResult> Index()
        {
            // return View(await _context.LeaveTypes.ToListAsync()); through we are returning LeaveType and hence brekaing the singleResponsibility principle.
            // so we will give ViewModel to view to show on UI
            // var leaveTypes = _mapper.Map<List<LeaveTypeVM>>(await _context.LeaveTypes.ToListAsync()); now use below instaed of this
            var leaveTypes = _mapper.Map<List<LeaveTypeVM>>(await leaveTypeRepository.GetAllAsync() );
            return View(leaveTypes);
        }

        // GET: LeaveTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var leaveType = await leaveTypeRepository.GetAsync(id);
            if (leaveType == null)
            {
                return NotFound();
            }
            var leaveTypeVm = _mapper.Map<LeaveTypeVM>(leaveType);
            return View(leaveTypeVm);
        }

        // GET: LeaveTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LeaveTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken] //it validates the antiforgerytoken which came with the form
        //public async Task<IActionResult> Create([Bind("Name,DefaultDays,ID,DateCreated,DateModified")] LeaveType leaveType) //bind helps protect against over posting. so if u send any addional column with post request, that would be filtered out
        //above commente as we will use viewModel isntead of model

        public async Task<IActionResult> Create( LeaveTypeVM leaveTypeVM)
        {
            if (ModelState.IsValid)
            {
                //only below 2 lines were required when using Model
                //_context.Add(leaveType);
                //await _context.SaveChangesAsync();

                //now use below for viewModel
                var leaveType = _mapper.Map<LeaveType>(leaveTypeVM);
                //_context.Add(leaveType);
                //await _context.SaveChangesAsync();
                await leaveTypeRepository.AddAsync(leaveType);
                return RedirectToAction(nameof(Index));
            }
            return View(leaveTypeVM);
        }

        // GET: LeaveTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
          
            var leaveType = await leaveTypeRepository.GetAsync (id);
            if (leaveType == null)
            {
                return NotFound();
            }
            var leaveTypeVM =  _mapper.Map<LeaveTypeVM>(leaveType);
            return View(leaveTypeVM);
        }

        // POST: LeaveTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,  LeaveTypeVM leaveTypeVM)
        {
            if (id != leaveTypeVM.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var leaveType = _mapper.Map<LeaveType>(leaveTypeVM);
                    //_context.Update(leaveType);
                    //await _context.SaveChangesAsync();
                    await leaveTypeRepository.UpdateAsync(leaveType);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await LeaveTypeExistsAsync(leaveTypeVM.ID))
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
            return View(leaveTypeVM);
        }

        // GET: LeaveTypes/Delete/5
      
        // POST: LeaveTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            //if (_context.LeaveTypes == null)
            //{
            //    return Problem("Entity set 'ApplicationDbContext.LeaveTypes'  is null.");
            //}
            //var leaveType = await _context.LeaveTypes.FindAsync(id);
            //if (leaveType != null)
            //{
            //    _context.LeaveTypes.Remove(leaveType);
            //}

            //await _context.SaveChangesAsync();
            await leaveTypeRepository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> LeaveTypeExistsAsync(int id)
        {
            return await leaveTypeRepository.Exists(id);
        }
    }
}
