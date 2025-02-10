namespace BAWLib.Entities;

public class GroupeStateService
{
    public int GroupId { get; set; }
    public void SetGroupData(int groupId){
        {
            GroupId = groupId;
        }
    }
}