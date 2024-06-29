using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A subclass of Building that produce resource at a constant rate.
/// </summary>
public class ResourcePile : Building
{
    public ResourceItem Item;

    //Variables Privadas
    private float m_ProductionSpeed = 0.5f;

    private float m_CurrentProduction = 0.0f;

    //Propiedades
    public float ProductionSpeed
    {
        get
        {
            return this.m_ProductionSpeed;
        }
        set
        {
            if (value < 0)
            {
                Debug.LogError("No se pueden asignar valores negativos a ProductionSpeed");
            }
            else
            {
                this.m_ProductionSpeed = value;
            }
        }
    }

    private void Update()
    {
        if (m_CurrentProduction > 1.0f)
        {
            int amountToAdd = Mathf.FloorToInt(m_CurrentProduction);
            int leftOver = AddItem(Item.Id, amountToAdd);

            m_CurrentProduction = m_CurrentProduction - amountToAdd + leftOver;
        }
        
        if (m_CurrentProduction < 1.0f)
        {
            m_CurrentProduction += m_ProductionSpeed * Time.deltaTime;
        }
    }

    public override string GetData()
    {
        return $"Producing at the speed of {m_ProductionSpeed}/s";
        
    }
    
    
}
