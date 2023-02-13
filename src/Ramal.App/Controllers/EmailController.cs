using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Ramal.App.Data;
using Ramal.App.Extensions;
using Ramal.App.ViewModels;
using Ramal.Business.Interfaces;
using Ramal.Business.Models;
using Ramal.Business.Services;
using Ramal.Data.Repository;

namespace Ramal.App.Controllers
{
    [Authorize]
    [ClaimsAuthorize("Admin_IT", "Admin_IT")]
    public class EmailController : Controller
    {

        private readonly IEmailRepository _emailRepository;
        private readonly IEmailService _emailService;
        private readonly ISetorRepository _setorRepository;
        private readonly IMapper _mapper;

        public EmailController(IEmailRepository emailRepository, IEmailService emailService, ISetorRepository setorRepository, IMapper mapper)
        {
            _emailRepository = emailRepository;
            _emailService = emailService;
            _setorRepository = setorRepository;
            _mapper = mapper;
        }



        // GET: Email
        [Route("CaixaEmail")]
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<EmailViewModel>>(await _emailRepository.ObterEmailsSetores()));
        }

        // GET: Email/Details/5
        [Route("CaixaEmail/{id:guid}")]
        public async Task<IActionResult> Details(Guid id)
        {
            var emailViewModel = await ObterEmail(id);
            if (emailViewModel == null)
            {
                return NotFound();
            }

            return View(emailViewModel);
        }

        // GET: Email/Create
        [Route("NovoEmail")]
        public async Task<IActionResult> Create()
        {
            var emailViewModel = await PopularSetores(new EmailViewModel());

            return View(emailViewModel);
        }

        // POST: Email/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("NovoEmail")]
        public async Task<IActionResult> Create(EmailViewModel emailViewModel)
        {
            emailViewModel = await PopularSetores(emailViewModel);
            if (!ModelState.IsValid) return View(emailViewModel);


            await _emailService.Adicionar(_mapper.Map<Email>(emailViewModel));
            return RedirectToAction(nameof(Index));
        }

        // GET: Email/Edit/5
        [Route("EditarEmail/{id:guid}")]
        public async Task<IActionResult> Edit(Guid id)
        {
            var emailViewModel = await ObterEmail(id);
            emailViewModel.Setores = _mapper.Map<IEnumerable<SetorViewModel>>(await _setorRepository.ObterTodos());

            if (emailViewModel == null)
            {
                return NotFound();
            }
            return View(emailViewModel);
        }

        // POST: Email/Edit/5
        [Route("EditarEmail/{id:guid}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, EmailViewModel emailViewModel)
        {
            if (id != emailViewModel.Id) return NotFound();

            if (!ModelState.IsValid) return View(emailViewModel);

            await _emailService.Atualizar(_mapper.Map<Email>(emailViewModel));


            return RedirectToAction(nameof(Index));
        }

        // GET: Email/Delete/5
        [Route("ExcluirEmail/{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var emailViewModel = await ObterEmail(id);

            if (emailViewModel == null) return NotFound();


            return View(emailViewModel);
        }

        // POST: Email/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Route("ExcluirEmail/{id:guid}")]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var emailViewModel = await ObterEmail(id);

            if (emailViewModel == null) return NotFound();


            await _emailService.Remover(id);
            return RedirectToAction(nameof(Index));
        }

        private async Task<EmailViewModel> PopularSetores(EmailViewModel email)
        {
            email.Setores = _mapper.Map<IEnumerable<SetorViewModel>>(await _setorRepository.ObterTodos());
            return email;
        }

        private async Task<EmailViewModel> ObterEmail(Guid id)
        {
            var email = _mapper.Map<EmailViewModel>(await _emailRepository.ObterEmailSetor(id));

            return email;
        }
    }
}
