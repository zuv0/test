using System;
using System.Collections.Generic;
using Rewired;
using UnityEngine;

[CreateAssetMenu(fileName = "new-controller-icon-mapping", menuName = "Controller Icon Mapping")]
public class ControllerIconMapDefinition : ScriptableObject
{
	[SerializeField]
	private InputIconMapDefinition microsoftGamepadMap;

	[SerializeField]
	private InputIconMapDefinition nintendoSwitchDualGamepadMap;

	[SerializeField]
	private InputIconMapDefinition nintendoSwitchHandheldAndProGamepadMap;

	[SerializeField]
	private InputIconMapDefinition sonyGamepadMap;

	[SerializeField]
	private InputIconMapDefinition keyboardMap;

	[SerializeField]
	private InputIconMapDefinition mouseMap;

	[SerializeField]
	private InputIcon EmptyIcon;

	private List<ControllerTemplateElementTarget> _elementTargets = new List<ControllerTemplateElementTarget>();

	public bool GetIconsForAction(int actionId, Pole pole, Player player, List<InputIcon> inputIcons)
	{
		try
		{
			Controller lastActiveController = player.controllers.GetLastActiveController();
			if (lastActiveController != null)
			{
				if (lastActiveController.type == ControllerType.Joystick)
				{
					if (lastActiveController.hardwareTypeGuid == new Guid("1fbdd13b-0795-4173-8a95-a2a75de9d204") || lastActiveController.hardwareTypeGuid == new Guid("7bf3154b-9db8-4d52-950f-cd0eed8a5819"))
					{
						FillInputIcons(inputIcons, nintendoSwitchHandheldAndProGamepadMap, player, lastActiveController, actionId, pole);
					}
					else if (lastActiveController.hardwareTypeGuid == new Guid("521b808c-0248-4526-bc10-f1d16ee76bf1"))
					{
						FillInputIcons(inputIcons, nintendoSwitchDualGamepadMap, player, lastActiveController, actionId, pole);
					}
					else if (lastActiveController.hardwareTypeGuid == new Guid("c3ad3cad-c7cf-4ca8-8c2e-e3df8d9960bb") || lastActiveController.hardwareTypeGuid == new Guid("71dfe6c8-9e81-428f-a58e-c7e664b7fbed") || lastActiveController.hardwareTypeGuid == new Guid("cd9718bf-a87a-44bc-8716-60a0def28a9f") || lastActiveController.hardwareTypeGuid == new Guid("5286706d-19b4-4a45-b635-207ce78d8394"))
					{
						FillInputIcons(inputIcons, sonyGamepadMap, player, lastActiveController, actionId, pole);
					}
					else
					{
						FillInputIcons(inputIcons, microsoftGamepadMap, player, lastActiveController, actionId, pole);
					}
				}
				else
				{
					FillInputIcons(inputIcons, keyboardMap, player, lastActiveController, actionId, pole);
					FillInputIcons(inputIcons, mouseMap, player, lastActiveController, actionId, pole);
				}
			}
		}
		catch
		{
			Debug.Log("No controller found");
		}
		return inputIcons.Count > 0;
	}

	public bool GetIconForStick(Structs.InputSticks stick, Player player, List<InputIcon> inputIcons)
	{
		try
		{
			Controller lastActiveController = player.controllers.GetLastActiveController();
			if (lastActiveController != null)
			{
				if (lastActiveController.type == ControllerType.Joystick)
				{
					if (lastActiveController.hardwareTypeGuid == new Guid("1fbdd13b-0795-4173-8a95-a2a75de9d204") || lastActiveController.hardwareTypeGuid == new Guid("7bf3154b-9db8-4d52-950f-cd0eed8a5819"))
					{
						FillInputCompleteStick(inputIcons, nintendoSwitchHandheldAndProGamepadMap, stick);
					}
					else if (lastActiveController.hardwareTypeGuid == new Guid("521b808c-0248-4526-bc10-f1d16ee76bf1"))
					{
						FillInputCompleteStick(inputIcons, nintendoSwitchDualGamepadMap, stick);
					}
					else if (lastActiveController.hardwareTypeGuid == new Guid("c3ad3cad-c7cf-4ca8-8c2e-e3df8d9960bb") || lastActiveController.hardwareTypeGuid == new Guid("71dfe6c8-9e81-428f-a58e-c7e664b7fbed") || lastActiveController.hardwareTypeGuid == new Guid("cd9718bf-a87a-44bc-8716-60a0def28a9f") || lastActiveController.hardwareTypeGuid == new Guid("5286706d-19b4-4a45-b635-207ce78d8394"))
					{
						FillInputCompleteStick(inputIcons, sonyGamepadMap, stick);
					}
					else
					{
						FillInputCompleteStick(inputIcons, microsoftGamepadMap, stick);
					}
				}
				else
				{
					FillInputCompleteStick(inputIcons, keyboardMap, stick);
					FillInputCompleteStick(inputIcons, mouseMap, stick);
				}
			}
		}
		catch
		{
			Debug.Log("No controller found");
		}
		return inputIcons.Count > 0;
	}

	public string ParseTextButtonIcons(string sentence)
	{
		string empty = string.Empty;
		bool flag = false;
		Controller lastControllerUsedForIcons = GameGrid.inputManager.GetLastControllerUsedForIcons();
		if (lastControllerUsedForIcons != null)
		{
			if (lastControllerUsedForIcons.type == ControllerType.Joystick)
			{
				empty = ((!(lastControllerUsedForIcons.hardwareTypeGuid == new Guid("3eb01142-da0e-4a86-8ae8-a15c2b1f2a04")) && !(lastControllerUsedForIcons.hardwareTypeGuid == new Guid("605dc720-1b38-473d-a459-67d5857aa6ea")) && !(lastControllerUsedForIcons.hardwareTypeGuid == new Guid("521b808c-0248-4526-bc10-f1d16ee76bf1")) && !(lastControllerUsedForIcons.hardwareTypeGuid == new Guid("1fbdd13b-0795-4173-8a95-a2a75de9d204")) && !(lastControllerUsedForIcons.hardwareTypeGuid == new Guid("7bf3154b-9db8-4d52-950f-cd0eed8a5819"))) ? ((!(lastControllerUsedForIcons.hardwareTypeGuid == new Guid("c3ad3cad-c7cf-4ca8-8c2e-e3df8d9960bb")) && !(lastControllerUsedForIcons.hardwareTypeGuid == new Guid("71dfe6c8-9e81-428f-a58e-c7e664b7fbed")) && !(lastControllerUsedForIcons.hardwareTypeGuid == new Guid("cd9718bf-a87a-44bc-8716-60a0def28a9f")) && !(lastControllerUsedForIcons.hardwareTypeGuid == new Guid("5286706d-19b4-4a45-b635-207ce78d8394"))) ? "_xbox" : "_playstation") : "_switch");
			}
			else
			{
				empty = "_pc";
				flag = true;
			}
			int num = sentence.IndexOf("#<");
			int num2 = sentence.IndexOf(">#");
			int num3 = sentence.IndexOf("{{");
			int num4 = sentence.IndexOf("}}");
			List<InputIcon> list = new List<InputIcon>();
			while (num != -1)
			{
				string oldValue = sentence.Substring(num + 1, num2 - num);
				num3 = sentence.IndexOf("{{");
				num4 = sentence.IndexOf("}}");
				string text = sentence.Substring(num3 + 2, num4 - num3 - 2);
				sentence = sentence.Remove(num2 + 1, 1);
				sentence = sentence.Remove(num, 1);
				if (flag)
				{
					string keyBindingName = GameGrid.inputManager.GetKeyBindingName(int.Parse(text), Pole.Positive);
					sentence = sentence.Replace(oldValue, keyBindingName);
				}
				else
				{
					GetIconsForAction(int.Parse(text), Pole.Positive, GameGrid.inputManager.Player, list);
					string keyBindingName = list[0].IconLabel;
					sentence = sentence.Replace("{{" + text + "}}", keyBindingName);
				}
				num = sentence.IndexOf("#<");
				num2 = sentence.IndexOf(">#");
			}
			sentence = sentence.Replace("_button_", "_button" + empty);
		}
		return sentence;
	}

	private void FillInputCompleteStick(List<InputIcon> inputIcons, InputIconMapDefinition iconMap, Structs.InputSticks stick)
	{
		inputIcons.Clear();
		InputIcon stick2 = iconMap.GetStick(stick);
		if (!string.IsNullOrEmpty(stick2.IconSkinName))
		{
			inputIcons.Add(stick2);
		}
		if (inputIcons.Count == 0)
		{
			inputIcons.Add(EmptyIcon);
		}
	}

	private void FillInputIcons(List<InputIcon> inputIcons, InputIconMapDefinition iconMap, Player player, Controller controller, int actionId, Pole pole)
	{
		IEnumerable<ActionElementMap> enumerable = player.controllers.maps.ElementMapsWithAction(controller, actionId, false);
		inputIcons.Clear();
		foreach (ActionElementMap item in enumerable)
		{
			if (controller.type == ControllerType.Joystick && item.axisContribution == pole)
			{
				InputIcon inputIcon = iconMap.GetInputIcon(item.elementIdentifierId, pole);
				if (!string.IsNullOrEmpty(inputIcon.IconSkinName))
				{
					inputIcons.Add(inputIcon);
				}
			}
		}
		if (inputIcons.Count == 0)
		{
			inputIcons.Add(EmptyIcon);
		}
	}
}
