using Microsoft.AspNetCore.Mvc;

[Route("api/Villa")]
[ApiController]
public class VillaController: ControllerBase {

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult<IEnumerable<VillaDTO>> GetVillas() {
        return Ok(VillaStore.villaList);
    }

    [HttpGet("{id:int}", Name="GetVilla")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<VillaDTO> GetOneVilla(int id) {
        if (id == 0) {
            return BadRequest();
        }
        
        var villaId = VillaStore.villaList.FirstOrDefault(u=>u.Id == id);
        if (villaId == null) {
            return NotFound();
        }

        return Ok(villaId);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult<VillaDTO> CreateVilla([FromBody]VillaDTO villaDTO) {
        if (villaDTO == null) {
            return BadRequest(villaDTO);
        }

        if (villaDTO.Id > 0) {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }

        villaDTO.Id = VillaStore.villaList.OrderByDescending(u=>u.Id).FirstOrDefault().Id + 1;
        VillaStore.villaList.Add(villaDTO);

        return CreatedAtRoute("GetVilla", new { id = villaDTO.Id }, villaDTO);
    }
}