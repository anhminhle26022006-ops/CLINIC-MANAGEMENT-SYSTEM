using System;

public class VitalSignsBUS
{
    private VitalSignsDAL dal = new VitalSignsDAL();

    public bool SaveVitalSigns(VitalSignDTO dto)
    {
        Validate(dto);

        return dal.InsertVitalSigns(dto);
    }

    private void Validate(VitalSignDTO dto)
    {
        if (dto.Temperature < 35 || dto.Temperature > 42)
        {
            throw new Exception("Temperature invalid");
        }

        if (dto.SPO2 < 0 || dto.SPO2 > 100)
        {
            throw new Exception("SPO2 invalid");
        }

        if (dto.HeartRate < 30 || dto.HeartRate > 220)
        {
            throw new Exception("Heart rate invalid");
        }

        if (dto.Weight <= 0)
        {
            throw new Exception("Weight invalid");
        }
    }
}