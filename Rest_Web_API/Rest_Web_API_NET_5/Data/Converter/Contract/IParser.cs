using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rest_Web_API_NET_5.Data.Converter.Contract
{
    public interface IParser<Origem, Destino>
    {

        Destino Parse(Origem origin);
        List<Destino> Parse(List<Origem> origin);
    }
}
