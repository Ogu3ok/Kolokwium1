using Kolos1.Models;
using Kolos1.Repositories;

namespace Kolos1.Services;

public class FireService
{
    private FireActionRepo _fireActionRepo;
    private FireFighterRepo _fireFighterRepo;
    private FireFighterActionRepo _fireFighter_ActionRepo;
    
    public FireService(FireActionRepo fireActionRepo, FireFighterRepo fireFighterRepo, FireFighterActionRepo fireFighter_ActionRepo)
    {
        _fireActionRepo = fireActionRepo;
        _fireFighterRepo = fireFighterRepo;
        _fireFighter_ActionRepo = fireFighter_ActionRepo;
    }
    
    public FireAction? GetFireAction(int id)
    {
        FireAction fireAction = _fireActionRepo.GetFireAction(id);
        if (fireAction == null) return null;
        IEnumerable<FirefighterAction> fireFighterAction = _fireFighter_ActionRepo.GetFireFighterAction(id);
        foreach (FirefighterAction firefighterAction in fireFighterAction)
        {
            var fireFighter = _fireFighterRepo.GetFirefighter(firefighterAction.IdFirefighter);
            if (fireFighter != null) 
                fireAction.Firefighters.Add(fireFighter);
        }
        return fireAction;
    }

    public int DeleteFireAction(int id)
    { 
        FireAction action= _fireActionRepo.GetFireAction(id);
        if (action.EndTime != null)
            return 0;
        int affectedCount = _fireActionRepo.DeleteFireAction(id);
        return affectedCount;
    }
}