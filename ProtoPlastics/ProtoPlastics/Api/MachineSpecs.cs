namespace ProtoPlastics.Api
{
    using System.Data;
    using System.Text.Json;
    using DataType = Data.MachineSpecs;
    public static class MachineSpecs
    {
        public static DataType Get()
        {
            using (var stream = new StreamReader("wwwroot/machine-specs.json"))
            {
                try
                {
                    string fileContent = stream.ReadToEnd();
                    DataType? data = JsonSerializer.Deserialize<DataType>(fileContent);
                    return data ?? DefaultMachineSpecs();
                }
                catch (Exception)
                {
                    return DefaultMachineSpecs();
                }
            }
        }

        private static DataType DefaultMachineSpecs()
        {
            return new DataType
            {
                Specs = new List<Data.Spec>{
                    new Data.Spec
                    {
                        Name = "",
                        ClampSpecs = new List<Data.ClampSpec>
                        {
                            new Data.ClampSpec{
                            Label = "",
                            Value = "",
                            Unit = "",
                            }
                        },
                        InjectionSpecs = new List<Data.InjectionSpec>{
                            new Data.InjectionSpec{
                            Label = "",
                            Value = "",
                            Unit = "",
                            }
                        },
                    }
                }
            };
        }
    }
}