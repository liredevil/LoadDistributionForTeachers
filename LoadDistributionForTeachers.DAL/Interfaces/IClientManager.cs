using LoadDistributionForTeachers.DAL.Entities;
using System;

namespace LoadDistributionForTeachers.DAL.Interfaces
{
    public interface IClientManager : IDisposable
    {
        void Create(ClientProfile item);
    }
}
