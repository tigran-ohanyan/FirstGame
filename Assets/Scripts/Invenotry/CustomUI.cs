#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
[CustomEditor(typeof(Player))]
public class CustomUI : Editor
{
    public override void OnInspectorGUI()
    {
        // Получаем ссылку на целевой объект (скрипт с массивом)
        Player arrayExample = (Player)target;

        // Заголовок
        EditorGUILayout.LabelField("2D Array Display", EditorStyles.boldLabel);

        // Проходим по каждому элементу двумерного массива
        for (int i = 0; i < arrayExample.items.GetLength(0); i++)
        {
            // Начинаем новую строку
            EditorGUILayout.BeginHorizontal();

            for (int j = 0; j < arrayExample.items.GetLength(1); j++)
            {
                // Рисуем текстовое поле для каждого элемента массива
                arrayExample.items[i, j] = EditorGUILayout.TextField(arrayExample.items[i, j]);
            }

            // Заканчиваем строку
            EditorGUILayout.EndHorizontal();
        }

        // Обновляем инспектор при изменениях
        if (GUI.changed)
        {
            EditorUtility.SetDirty(arrayExample);
        }
    }
}

#endif