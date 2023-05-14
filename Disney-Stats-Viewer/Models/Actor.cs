namespace Disney_Stats_Viewer.Models;

public class Actor
{
    Int32 actor_id { get; set; }
    String actor_name { get; set; }
    
    public Actor(Int32 actor_id, String actor_name)
    {
        this.actor_id = actor_id;
        this.actor_name = actor_name;
    }
    
    public Int32 getActorId()
    {
        return actor_id;
    }
    
    public String getActorName()
    {
        return actor_name;
    }
    
    public void setActorId(Int32 actor_id)
    {
        this.actor_id = actor_id;
    }
    
    public void setActorName(String actor_name)
    {
        this.actor_name = actor_name;
    }
    
    public override String ToString()
    {
        return "Actor ID: " + actor_id + " Actor Name: " + actor_name;
    }
    
    public override bool Equals(Object obj)
    {
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }
        
        Actor actor = (Actor) obj;
        return actor_id == actor.getActorId() && actor_name == actor.getActorName();
    }
    
    public override int GetHashCode()
    {
        return HashCode.Combine(actor_id, actor_name);
    }
    
    public static bool operator ==(Actor actor1, Actor actor2)
    {
        return actor1.Equals(actor2);
    }
    
    public static bool operator !=(Actor actor1, Actor actor2)
    {
        return !actor1.Equals(actor2);
    }
    
    public static bool operator >(Actor actor1, Actor actor2)
    {
        return actor1.getActorId() > actor2.getActorId();
    }
    
    public static bool operator <(Actor actor1, Actor actor2)
    {
        return actor1.getActorId() < actor2.getActorId();
    }
    
    public static bool operator >=(Actor actor1, Actor actor2)
    {
        return actor1.getActorId() >= actor2.getActorId();
    }
    
    public static bool operator <=(Actor actor1, Actor actor2)
    {
        return actor1.getActorId() <= actor2.getActorId();
    }
    
    public static Actor operator +(Actor actor1, Actor actor2)
    {
        return new Actor(actor1.getActorId() + actor2.getActorId(), actor1.getActorName() + actor2.getActorName());
    }
    
}