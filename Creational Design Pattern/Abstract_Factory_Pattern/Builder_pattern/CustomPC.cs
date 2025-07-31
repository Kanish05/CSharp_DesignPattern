using System;
public class PC{
    public string CPU {get; set;}
    public int Ram {get; set;}
    public int Storage {get; set;}
    public int GPU {get; set;}
    public int PowerSupply {get; set;}
    public string OS {get; set;}
    
    public override string ToString(){
        return $"PC[CPU = {CPU} , RamStorage = {Storage} , GPU =  {GPU} , PowerSupply= {PowerSupply} , OS= {OS}]";
    }
}

public class PCMannual{
    public string content{get;set;} = "";
    public void AddContent(string section){
        content += section ;
    }
    public override string ToString(){
        return $"Mannual\n"+content;
    }
}

public interface IBuilder{
    void BuildCPU(string type);
    void BuildRam(int size);
    void BuildStorage(int size);
    void BuildGPU(int size);
    void BuildPowerSupply (int watts);
    void BuildOS(string type);
}

public class PCBuilder : IBuilder {
    private PC pc;
    
    public PCBuilder(){
        Reset();
    }
    
    public void Reset(){
        pc = new PC();
    }
    
    public void BuildCPU(string type){
        pc.CPU = type;
    }
    public void BuildRam(int size){
        pc.Ram = size;
    }
    public void BuildStorage(int size){
        pc.Storage = size;
    }
    public void BuildGPU(int size){
        pc.GPU = size;
    }
    public void BuildPowerSupply (int watts){
        pc.PowerSupply = watts;
    }
    public void BuildOS(string type){
        pc.OS = type;
    }
    
    public PC GetProduct(){
        PC product = pc;
        Reset();
        return product;
    }
    
}

public class PCMannualBuilder : IBuilder {
    private PCMannual pcm;
    
    public PCMannualBuilder(){
        Reset();
    }
    
    public void Reset(){
        pcm = new PCMannual();
    }
    
    public void BuildCPU(string type){
        pcm.AddContent($"CPU type = {type}");
    }
    public void BuildRam(int size){
        pcm.AddContent($"Ram cap.= {size}");
    }
    public void BuildStorage(int size){
        pcm.AddContent($"Storage cap.= {size}");
    }
    public void BuildGPU(int size){
        pcm.AddContent($"GPU cap.= {size}");
    }
    public void BuildPowerSupply (int watts){
        pcm.AddContent($"PowerSupply cap.= {watts} W");
    }
    public void BuildOS(string type){
        pcm.AddContent($"OS type= {type}");
    }
    
    public PCMannual GetProduct(){
        PCMannual product = pcm;
        Reset();
        return product;
    }
}

public class Director{
    public void BuildGamingPC(IBuilder builder){
        builder.BuildCPU("Gaming");
        builder.BuildRam(12);
        builder.BuildStorage(512);
        builder.BuildGPU(8);
        builder.BuildPowerSupply (50);
        builder.BuildOS("Windows");
    }
    
    public void BuildOfficePC(IBuilder builder){
        builder.BuildCPU("Office");
        builder.BuildRam(12);
        builder.BuildStorage(512);
        builder.BuildGPU(8);
        builder.BuildPowerSupply (50);
        builder.BuildOS("Linux");
    }
    
    public void BuildBudgetPC(IBuilder builder){
        builder.BuildCPU("Budget");
        builder.BuildRam(12);
        builder.BuildStorage(512);
        builder.BuildGPU(8);
        builder.BuildPowerSupply (50);
        builder.BuildOS("IOS");
    }
}


public class Application {
    public void PCBuilder(){
      Director dir = new Director();
      PCBuilder pcb = new PCBuilder();
      dir.BuildGamingPC(pcb);
      PC productpc = pcb.GetProduct();
      Console.WriteLine(productpc);
      
      PCMannualBuilder pcmb = new PCMannualBuilder();
      dir.BuildGamingPC(pcmb);
      PCMannual productpcm = pcmb.GetProduct();
      Console.WriteLine(productpcm);
    }
    
    public static void Main(string[] args){
        Application app = new Application();
        app.PCBuilder();
    }
}