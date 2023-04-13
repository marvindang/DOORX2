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
using System.Security.AccessControl;

namespace DOOR.Server.Controllers.UD
{
    [ApiController]
    [Route("api/[controller]")]
    public class ZipCodeController : BaseController
    {
        public ZipCodeController(DOOROracleContext _DBcontext,
            OraTransMsgs _OraTransMsgs)
            : base(_DBcontext, _OraTransMsgs)

        {
        }


        [HttpGet]
        [Route("GetZipCode")]
        public async Task<IActionResult> ZipCode()
        {
            List<ZipcodeDTO> lst = await _context.Zipcodes
                .Select(sp => new ZipcodeDTO
                {
                    Zip = sp.Zip,
                    City = sp.City,
                    State = sp.State,


                }).ToListAsync();
            return Ok(lst);
        }


        [HttpGet]
        [Route("GetZipCode/{_Zip}")]
        public async Task<IActionResult> GetZipCode(String _ZipCode)
        {
            ZipcodeDTO? lst = await _context.Zipcodes
               .Where(x => x.Zip == _ZipCode)
               .Select(sp => new ZipcodeDTO
               {
                   Zip = sp.Zip,
                   City = sp.City,
                   State = sp.State,

               }).FirstOrDefaultAsync();
            return Ok(lst);
        }


        [HttpPost]
        [Route("PostZipCode")]
        public async Task<IActionResult> PostCourse([FromBody] ZipcodeDTO _Zipcode)
        {
            try
            {
                Zipcode c = await _context.Zipcodes.Where(x => x.Zip == _Zipcode.Zip).FirstOrDefaultAsync();

                if (c == null)
                {
                    c = new Zipcode
                    {
                        Zip = _Zipcode.Zip,
                        City = _Zipcode.City,
                        State = _Zipcode.State,

                    };
                    _context.Zipcodes.Add(c);
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
        [Route("PutZipCode")]
        public async Task<IActionResult> PutCourse([FromBody] ZipcodeDTO _ZipCodes)
        {
            try
            {
                Zipcode c = await _context.Zipcodes.Where(x => x.Zip == _Zipcodes.Zip).FirstOrDefaultAsync();

                if (c != null)
                {
                    c.Zip = _ZipCodes.Zip;
                    c.City = _ZipCodes.City;
                    c.State = _ZipCodes.State;


                    _context.Zipcodes.Update(c);
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
        [Route("DeleteZipcode/{_Zipcode}")]
        public async Task<IActionResult> DeleteCourse(String _Zipcode)
        {
            try
            {
                Zipcode c = await _context.Zipcodes.Where(x => x.Zip == _Zipcode).FirstOrDefaultAsync();

                if (c != null)
                {
                    _context.Zipcodes.Remove(c);
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