using Microsoft.AspNetCore.Mvc;

[Route("api/Villa")]
[ApiController]
public class VillaController: ControllerBase {

    [HttpGet]
    public IEnumerable<VillaDTO> GetVillas() {
        return VillaStore.villaList;
    }

    [HttpGet("id:int")]
    public VillaDTO GetOneVilla(int id) {
        return VillaStore.villaList.FirstOrDefault(u=>u.Id == id);
    }
}