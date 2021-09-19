using _1337Corp.PetShopApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1337Corp.PetShopApp.Core.IServices
{
    public interface IPetTypeService
    {
        List<PetType> GetAll();
        PetType GetPetTypeById(int id);
        PetType CreateType(PetType petType);
        void InitData();
    }
}
