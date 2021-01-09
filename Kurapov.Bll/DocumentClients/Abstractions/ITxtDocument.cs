using Kurapov.DAL.Entities;

namespace Kurapov.Bll.HttpClients.Abstractions
{
    public interface ITxtDocument
    {
        Document Read();
        Document Write();

        void Save(Document txtDoc);
    }
}
