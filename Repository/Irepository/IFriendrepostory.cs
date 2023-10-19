using Arangodbtest.model;

namespace Arangodbtest.Repository.Irepository
{
    public interface IFriendrepostory
    {
        ICollection<Friends> GetFriendRelation();
        void addFriendRelation(Friends friend);
        void updateRelation(Friends friend);
        void deleteRelation(string _key);

    }
}
