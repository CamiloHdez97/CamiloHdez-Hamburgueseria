using AutoMapper;
using Dominio;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

 public class HamburguesaController : BaseApiController
{
     private readonly IUnitOfWork unitofwork;
     private readonly IMapper mapper;

    public HamburguesaController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitofwork = unitOfWork;
        this.mapper = mapper;
    }
    
    //Retorna Registros de la Tabla
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<Hamburguesa>>> Get()
    {
        var Con = await  unitofwork.Hamburguesas.GetAllAsync();
        return Ok(Con);
    }

    //Retorna Registro de la Tabla, apartir del ID
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
      public async Task<IActionResult> Get(int id)
    {
        var byidC = await  unitofwork.Hamburguesas.GetByIdAsync(id);
        return Ok(byidC);
    }

    //Recibe un Post
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Hamburguesa>> Post(Hamburguesa hamburguesa){
        this.unitofwork.Hamburguesas.Add(hamburguesa);                                 //Agrega Información al Contexto
        await unitofwork.SaveAsync();                                           //Envia la Info del contexto a la DB
        if(hamburguesa == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post),new {id= hamburguesa.Id}, hamburguesa);     //Retorna el id del Valor generado
    }


    //Recibe un Put
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Hamburguesa>> Put(int id, [FromBody]Hamburguesa hamburguesa){ //Contiene la info a actualizar
        if(hamburguesa == null)
            return NotFound();
        unitofwork.Hamburguesas.Update(hamburguesa);                                        //Actua en el context
        await unitofwork.SaveAsync();                                                //Guarda la actualización
        return hamburguesa;                                                              //Efectua el update en la DB
    }



    //Recibe un Delete
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
        var Dir = await unitofwork.Hamburguesas.GetByIdAsync(id); //Busca y almacena el Registro a eliminar
        if(Dir == null){                                       //Valida si se encontro el registro
            return NotFound();                                 //Retorna NotFound
        }
        unitofwork.Hamburguesas.Remove(Dir);
        await unitofwork.SaveAsync();
        return NoContent();                                    //No retorna nada
    }


   
}