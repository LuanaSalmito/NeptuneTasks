using NeptuneTasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

public class NEquipe
{
    private static List<Equipe> Equipes = new List<Equipe>();


    public static void Abrir()
    {
        XmlSerializer xml = new XmlSerializer(typeof(List<Equipe>));
        StreamReader reader = null;
        try
        {
            reader = new StreamReader("Equipes.xml");
            Equipes = (List<Equipe>)xml.Deserialize(reader);
        }
        catch
        {
            Equipes = new List<Equipe>();
        }
        finally
        {
            if (reader != null) reader.Close();
        }
    }
    public static void Salvar()
    {
        XmlSerializer xml = new XmlSerializer(typeof(List<Equipe>));
        using (StreamWriter writer = new StreamWriter("Equipes.xml"))
        {
            xml.Serialize(writer, Equipes);
        }
    }
    public static Equipe Listar(string Nome)
    {
        foreach (Equipe obj in Equipes)
            if (obj.NomeEquipe == Nome) return obj;
        return null;
    }
    /* public static Equipe ListarEquipesUsuario(Usuario u)
     {
         foreach (Equipe obj in Equipes)
             if (obj.User = u.Id) return obj;
         return null;
     }*/

    public static void Excluir(Equipe t)
    {
        Equipe obj = Listar(t.NomeEquipe);
        if (obj != null) Equipes.Remove(obj);
    }
    public static void Inserir(Equipe equipe, Usuario usuariocriador, string descricao) // Recebe também o ID do usuário associado à Equipe
    {
        int id = 0;
        foreach (Equipe obj in Equipes)
            if (obj.idEquipe > id) id = obj.idEquipe;
        id++;

        equipe.idEquipe = id;
        equipe.admin = usuariocriador; // Associa o usuário criador como o administrador da equipe
        equipe.descricao = descricao; // Define a descrição da equipe

        // Se a lista de membros não tiver sido inicializada, crie uma nova lista vazia
        if (equipe.Membros == null)
            equipe.Membros = new List<Usuario>();

        // Adicione o usuário criador como membro da equipe
        equipe.Membros.Add(usuariocriador);

        Equipes.Add(equipe);
    }
}
    /*public static List<Equipe> ListarEquipesUsuario(Usuario usuario)
    {
        List<Equipe> EquipesUsuario = new List<Equipe>();

        foreach (Equipe Equipe in Equipes)
        {
            if (Equipe.IdUsuario == usuario.Id)
            {
                EquipesUsuario.Add(Equipe);
            }
        }

        return EquipesUsuario;
    }*/

