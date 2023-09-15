using AutoMapper;
using Dominio;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

 public class CategoriaController : BaseApiController
{
     private readonly IUnitOfWork unitofwork;
     private readonly IMapper mapper;

    public CategoriaController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitofwork = unitOfWork;
        this.mapper = mapper;
    }
    
    //Retorna Registros de la Tabla
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<Categoria>>> Get()
    {
        var Con = await  unitofwork.Categorias.GetAllAsync();
        return Ok(Con);
    }

    //Retorna Registro de la Tabla, apartir del ID
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
      public async Task<IActionResult> Get(int id)
    {
        var byidC = await  unitofwork.Categorias.GetByIdAsync(id);
        return Ok(byidC);
    }


    //Recibe un Post
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Categoria>> Post(Categoria categoria){
        this.unitofwork.Categorias.Add(categoria);                                 //Agrega Información al Contexto
        await unitofwork.SaveAsync();                                           //Envia la Info del contexto a la DB
        if(categoria == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post),new {id= categoria.Id}, categoria);     //Retorna el id del Valor generado
    }


    //Recibe un Put
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Categoria>> Put(int id, [FromBody]Categoria categoria){ //Contiene la info a actualizar
        if(categoria == null)
            return NotFound();
        unitofwork.Categorias.Update(categoria);                                        //Actua en el context
        await unitofwork.SaveAsync();                                                //Guarda la actualización
        return categoria;                                                              //Efectua el update en la DB
    }



    //Recibe un Delete
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
        var Dir = await unitofwork.Categorias.GetByIdAsync(id); //Busca y almacena el Registro a eliminar
        if(Dir == null){                                       //Valida si se encontro el registro
            return NotFound();                                 //Retorna NotFound
        }
        unitofwork.Categorias.Remove(Dir);
        await unitofwork.SaveAsync();
        return NoContent();                                    //No retorna nada
    }


   
}