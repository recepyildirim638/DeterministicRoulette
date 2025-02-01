using System.Collections;
using System.Collections.Generic;

public class DataManager : BaseGameData
{
   

    public void Initalize() => LoadGameData();

    public PlayerData GetPlayerData() => this.playerData;
    public MainData GetMainData() => this.mainData;

    public List<SpinData> GetSprinData() => this.spinData;

    public void AddStatisticData(SpinData spinData) => this.spinData.Add(spinData);
  
}
