using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMovement_Application.Common.AutoMapper
{
    public interface IMap<T>
    {
        void Mapping(Profile profile);
    }
}