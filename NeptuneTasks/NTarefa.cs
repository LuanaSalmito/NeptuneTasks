using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

public class NTarefa
{
    private static List<Tarefa> tarefas = new List<Tarefa>();


    public static void Abrir()
    {
        XmlSerializer xml = new XmlSerializer(typeof(List<Tarefa>));
        StreamReader reader = null;
        try
        {
            reader = new StreamReader("tarefas.xml");
            tarefas = (List<Tarefa>)xml.Deserialize(reader);
        }
        catch
        {
            tarefas = new List<Tarefa>();
        }
        finally
        {
            if (reader != null) reader.Close();
        }
    }
    public static void Salvar()
    {
        XmlSerializer xml = new XmlSerializer(typeof(List<Tarefa>));
        using (StreamWriter writer = new StreamWriter("tarefas.xml"))
        {
            xml.Serialize(writer, tarefas);
        }
    }
    public static Tarefa Listar(string Nome)
    {
        foreach (Tarefa obj in tarefas)
            if (obj.Titulo == Nome) return obj;
        return null;
    }
   /* public static Tarefa ListarTarefasUsuario(Usuario u)
    {
        foreach (Tarefa obj in tarefas)
            if (obj.User = u.Id) return obj;
        return null;
    }*/

    public static void Excluir(Tarefa t)
    {
        Tarefa obj = Listar(t.Titulo);
        if (obj != null) tarefas.Remove(obj);
    }
    public static void Inserir(Tarefa task, int userId) // Recebe também o ID do usuário associado à tarefa
    {
        int id = 0;
        foreach (Tarefa obj in tarefas)
            if (obj.IdTarefa > id) id = obj.IdTarefa;
        id++;
        task.IdTarefa = id;
        task.IdUsuario = userId; // Associa o ID do usuário à tarefa
        tarefas.Add(task);
    }
    public static List<Tarefa> ListarTarefasUsuario(Usuario usuario)
    {
        List<Tarefa> tarefasUsuario = new List<Tarefa>();

        foreach (Tarefa tarefa in tarefas)
        {
            if (tarefa.IdUsuario == usuario.Id)
            {
                tarefasUsuario.Add(tarefa);
            }
        }

        return tarefasUsuario;
    }

}

