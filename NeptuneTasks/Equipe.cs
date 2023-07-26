using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Equipe
{
    public string NomeEquipe { get; set; }

    public Usuario admin { get; set; }

    public int idEquipe { get; set; }

    public string descricao { get; set; }

    public List<Usuario> Membros { get; set; }
    
}
  