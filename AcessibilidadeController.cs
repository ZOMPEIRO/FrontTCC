using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FrontendTCC.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FrontendTCC.Controllers
{
    public class AcessibilidadeController : Controller
    {
        public string uriBase ="http://felzompeiro.somee.com/";

        [HttpGet]
public async Task<ActionResult> IndexAsync()
{
    try
    {
        string uriComplementar = "GetAll";
        HttpClient httpClient = new HttpClient();
        //string token = HttpContext.Session.GetString("SessionTokenUsuario");
       // httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

        HttpResponseMessage response = await httpClient.GetAsync(uriBase + uriComplementar);
        string serialized = await response.Content.ReadAsStringAsync();

        if (response.StatusCode == System.Net.HttpStatusCode.OK)
        {
            List<AcessibilidadeViewlModel> listaAcessibilidade = await Task.Run(() =>
                JsonConvert.DeserializeObject<List<AcessibilidadeViewlModel>>(serialized));

            return View(listaAcessibilidade);
        }
        else
        {
            throw new System.Exception(serialized);
        }
    }
    catch (System.Exception ex)
    {
        TempData["MensagemErro"] = ex.Message;
         return View(new List<AcessibilidadeViewlModel>());
    }
}

    }
}