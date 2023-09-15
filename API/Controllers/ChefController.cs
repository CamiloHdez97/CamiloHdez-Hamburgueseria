using AutoMapper;
using Dominio;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;
namespace API.Controllers;

 public class ChefController : BaseApiController
{
     private readonly IUnitOfWork unitofwork;
     private readonly IMapper mapper;

    public ChefController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitofwork = unitOfWork;
        this.mapper = mapper;
    }
    
    //Retorna Registros de la Tabla
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<Chef>>> Get()
    {
        var Con = await  unitofwork.Chefs.GetAllAsync();
        return Ok(Con);
    }

    //Retorna Registro de la Tabla, apartir del ID
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
      public async Task<IActionResult> Get(int id)
    {
        var byidC = await  unitofwork.Chefs.GetByIdAsync(id);
        return Ok(byidC);
    }


    //Recibe un Post
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Chef>> Post(Chef chef){
        this.unitofwork.Chefs.Add(chef);                                 //Agrega Información al Contexto
        await unitofwork.SaveAsync();                                           //Envia la Info del contexto a la DB
        if(chef == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post),new {id= chef.Id}, chef);     //Retorna el id del Valor generado
    }


    //Recibe un Put
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Chef>> Put(int id, [FromBody]Chef chef){ //Contiene la info a actualizar
        if(chef == null)
            return NotFound();
        unitofwork.Chefs.Update(chef);                                        //Actua en el context
        await unitofwork.SaveAsync();                                                //Guarda la actualización
        return chef;                                                              //Efectua el update en la DB
    }



    //Recibe un Delete
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
        var Dir = await unitofwork.Chefs.GetByIdAsync(id); //Busca y almacena el Registro a eliminar
        if(Dir == null){                                       //Valida si se encontro el registro
            return NotFound();                                 //Retorna NotFound
        }
        unitofwork.Chefs.Remove(Dir);
        await unitofwork.SaveAsync();
        return NoContent();                                    //No retorna nada
    }

}