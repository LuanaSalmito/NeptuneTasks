using NeptuneTasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

public class NEquipe
{
    public static List<Equipe> equipes = new List<Equipe>();
    public static List<Equipe> Equipes
    {
        get { return equipes; }
    }
    public static void Abrir()
    {
        XmlSerializer xml = new XmlSerializer(typeof(List<Equipe>));
        StreamReader reader = null;
        try
        {
            reader = new StreamReader("equipes.xml");
            equipes = (List<Equipe>)xml.Deserialize(reader);
        }
        catch
        {
            equipes = new List<Equipe>();
        }
        finally
        {
            if (reader != null) reader.Close();
        }
    }

    public static void Salvar()
    {
        XmlSerializer xml = new XmlSerializer(typeof(List<Equipe>));
        using (StreamWriter writer = new StreamWriter("equipes.xml"))
        {
            xml.Serialize(writer, equipes);
        }
    }

    public static Equipe Listar(int idEquipe)
    {
        foreach (Equipe equipe in equipes)
        {
            if (equipe.idEquipe == idEquipe)
            {
                return equipe;
            }
        }
        return null;
    }

    public static void Excluir(Equipe equipe)
    {
        Equipe obj = Listar(equipe.idEquipe);
        if (obj != null)
        {
            equipes.Remove(obj);
        }
    }

    public static void Inserir(Equipe equipe)
    {
        // Verifica se a equipe já existe pelo seu idEquipe
        if (Listar(equipe.idEquipe) == null)
        {
            equipes.Add(equipe);
        }
        else
        {
            // Caso a equipe já exista, atualiza os dados da equipe
            Atualizar(equipe);
        }
    }

    public static void Atualizar(Equipe equipe)
    {
        Equipe obj = Listar(equipe.idEquipe);
        if (obj != null)
        {
            // Atualiza os dados da equipe com os novos valores
            obj.NomeEquipe = equipe.NomeEquipe;
            obj.admin = equipe.admin;
            obj.descricao = equipe.descricao;
            obj.Membros = equipe.Membros;
        }
    }
    public static int GerarNovoIdEquipe()
    {
        int maiorId = 0;
        foreach (Equipe equipe in equipes)
        {
            if (equipe.idEquipe > maiorId)
            {
                maiorId = equipe.idEquipe;
            }
        }
        return maiorId + 1; // Incrementa 1 ao maior ID encontrado para obter o novo ID da equipe
    }
    public static List<Equipe> ListarEquipeAdmin(Usuario usuario)
    {
        List<Equipe> equipesUsuario = new List<Equipe>();

        foreach (Equipe equipe in NEquipe.Equipes)
        {
            if (equipe.admin == usuario)
            {
                equipesUsuario.Add(equipe);
            }
        }

        return equipesUsuario;
    }

}

