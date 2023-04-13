using DOOR.EF.Data;
using DOOR.EF.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.Extensions.Caching.Memory;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Options;
using System.Security.Cryptography;
using System.Text.Json;
using System.Runtime.InteropServices;
using Microsoft.Extensions.Hosting.Internal;
using System.Net.Http.Headers;
using System.Drawing;
using Microsoft.AspNetCore.Identity;
using DOOR.Server.Models;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Data;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using System.Numerics;
using DOOR.Shared.DTO;
using DOOR.Shared.Utils;
using DOOR.Server.Controllers.Common;



namespace DOOR.Server.Controllers.UD
{
    [ApiController]
    [Route("api/[controller]")]
    public class SchoolController : BaseController
    {
        public SchoolController(DOOROracleContext _DBcontext,
            OraTransMsgs _OraTransMsgs)
            : base(_DBcontext, _OraTransMsgs)

        {
        }


        [HttpGet]
        [Route("GetSchools")]
        public async Task<IActionResult> GetSchool()
        {
            List<SchoolDTO> lst = await _context.Schools
                .Select(sp => new SchoolDTO
                {
                    SchoolId = sp.SchoolId,
                    SchoolName = sp.SchoolName,
                    CreatedBy = sp.CreatedBy,
                    CreatedDate = sp.CreatedDate,
                    ModifiedBy = sp.ModifiedBy,
                    ModifiedDate = sp.ModifiedDate


                }).ToListAsync();
            return Ok(lst);
        }


        [HttpGet]
        [Route("GetSchools/{_SchoolID}")]
        public async Task<IActionResult> GetSchoolID(int _SchoolID)
        {
            SchoolDTO? lst = await _context.Schools
                .Where(x => x.SchoolId == _SchoolID)
                .Select(sp => new SchoolDTO
                {
                    SchoolId = sp.SchoolId,
                    SchoolName = sp.SchoolName,
                    CreatedBy = sp.CreatedBy,
                    CreatedDate = sp.CreatedDate,
                    ModifiedBy = sp.ModifiedBy,
                    ModifiedDate = sp.ModifiedDate
                }).FirstOrDefaultAsync();
            return Ok(lst);
        }


        [HttpPost]
        [Route("PostSchool")]
        public async Task<IActionResult> PostSchool([FromBody] SchoolDTO _schoolDTO)
        {
            try
            {
                School c = await _context.Schools.Where(x => x.SchoolId == _schoolDTO.SchoolId).FirstOrDefaultAsync();

                if (c == null)
                {
                    c = new School
                    {
                        SchoolId = _schoolDTO.SchoolId,
                        SchoolName = _schoolDTO.SchoolName,
                        CreatedBy = _schoolDTO.CreatedBy,
                        CreatedDate = _schoolDTO.CreatedDate
                    };
                    _context.Schools.Add(c);
                    await _context.SaveChangesAsync();
                }
            }

            catch (DbUpdateException Dex)
            {
                List<OraError> DBErrors = ErrorHandling.TryDecodeDbUpdateException(Dex, _OraTranslateMsgs);
                return StatusCode(StatusCodes.Status417ExpectationFailed, Newtonsoft.Json.JsonConvert.SerializeObject(DBErrors));
            }
            catch (Exception ex)
            {
                _context.Database.RollbackTransaction();
                List<OraError> errors = new List<OraError>();
                errors.Add(new OraError(1, ex.Message.ToString()));
                string ex_ser = Newtonsoft.Json.JsonConvert.SerializeObject(errors);
                return StatusCode(StatusCodes.Status417ExpectationFailed, ex_ser);
            }

            return Ok();
        }








        [HttpPut]
        [Route("PutSChool")]
        public async Task<IActionResult> PutSchool([FromBody] SchoolDTO _SchoolDTO)
        {
            try
            {
                School c = await _context.Schools.Where(x => x.SchoolId == _SchoolDTO.SchoolId).FirstOrDefaultAsync();

                if (c != null)
                {
                    c.SchoolId = _SchoolDTO.SchoolId;
                    c.SchoolName = _SchoolDTO.SchoolName;
                    c.CreatedBy = _SchoolDTO.CreatedBy;
                    c.CreatedDate = _SchoolDTO.CreatedDate;

                    _context.Schools.Update(c);
                    await _context.SaveChangesAsync();
                }
            }

            catch (DbUpdateException Dex)
            {
                List<OraError> DBErrors = ErrorHandling.TryDecodeDbUpdateException(Dex, _OraTranslateMsgs);
                return StatusCode(StatusCodes.Status417ExpectationFailed, Newtonsoft.Json.JsonConvert.SerializeObject(DBErrors));
            }
            catch (Exception ex)
            {
                _context.Database.RollbackTransaction();
                List<OraError> errors = new List<OraError>();
                errors.Add(new OraError(1, ex.Message.ToString()));
                string ex_ser = Newtonsoft.Json.JsonConvert.SerializeObject(errors);
                return StatusCode(StatusCodes.Status417ExpectationFailed, ex_ser);
            }

            return Ok();
        }


        [HttpDelete]
        [Route("DeleteSchool/{_SchoolID}")]
        public async Task<IActionResult> DeleteSchool(int _SchoolID)
        {
            try
            {
                School c = await _context.Schools.Where(x => x.SchoolId == _SchoolID).FirstOrDefaultAsync();

                if (c != null)
                {
                    _context.Schools.Remove(c);
                    await _context.SaveChangesAsync();
                }
            }

            catch (DbUpdateException Dex)
            {
                List<OraError> DBErrors = ErrorHandling.TryDecodeDbUpdateException(Dex, _OraTranslateMsgs);
                return StatusCode(StatusCodes.Status417ExpectationFailed, Newtonsoft.Json.JsonConvert.SerializeObject(DBErrors));
            }
            catch (Exception ex)
            {
                _context.Database.RollbackTransaction();
                List<OraError> errors = new List<OraError>();
                errors.Add(new OraError(1, ex.Message.ToString()));
                string ex_ser = Newtonsoft.Json.JsonConvert.SerializeObject(errors);
                return StatusCode(StatusCodes.Status417ExpectationFailed, ex_ser);
            }

            return Ok();
        }



    }
}