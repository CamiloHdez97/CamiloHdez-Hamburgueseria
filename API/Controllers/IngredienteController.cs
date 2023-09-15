using AutoMapper;
using Dominio;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

 public class IngredienteController : BaseApiController
{
     private readonly IUnitOfWork unitofwork;
     private readonly IMapper mapper;

    public IngredienteController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitofwork = unitOfWork;
        this.mapper = mapper;
    }
    
    //Retorna Registros de la Tabla
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<Ingrediente>>> Get()
    {
        var Con = await  unitofwork.Ingredientes.GetAllAsync();
        return Ok(Con);
    }

    //Retorna Registro de la Tabla, apartir del ID
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
      public async Task<IActionResult> Get(int id)
    {
        var byidC = await  unitofwork.Ingredientes.GetByIdAsync(id);
        return Ok(byidC);
    }

    //Recibe un Post
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Ingrediente>> Post(Ingrediente Ingrediente){
        this.unitofwork.Ingredientes.Add(Ingrediente);                                 //Agrega Información al Contexto
        await unitofwork.SaveAsync();                                           //Envia la Info del contexto a la DB
        if(Ingrediente == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post),new {id= Ingrediente.Id}, Ingrediente);     //Retorna el id del Valor generado
    }

    //Recibe un Put
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Ingrediente>> Put(int id, [FromBody]Ingrediente Ingrediente){ //Contiene la info a actualizar
        if(Ingrediente == null)
            return NotFound();
        unitofwork.Ingredientes.Update(Ingrediente);                                        //Actua en el context
        await unitofwork.SaveAsync();                                                //Guarda la actualización
        return Ingrediente;                                                              //Efectua el update en la DB
    }

    //Recibe un Delete
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
        var Dir = await unitofwork.Ingredientes.GetByIdAsync(id); //Busca y almacena el Registro a eliminar
        if(Dir == null){                                       //Valida si se encontro el registro
            return NotFound();                                 //Retorna NotFound
        }
        unitofwork.Ingredientes.Remove(Dir);
        await unitofwork.SaveAsync();
        return NoContent();                                    //No retorna nada
    }

}