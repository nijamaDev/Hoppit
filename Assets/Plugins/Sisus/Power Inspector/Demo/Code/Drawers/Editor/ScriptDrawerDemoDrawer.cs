﻿using System;
using UnityEngine;
using Sisus.Attributes;

namespace Sisus.Demo
{
	[Serializable, DrawerForComponent(typeof(ScriptDrawerDemo))]
	public sealed class ScriptDrawerDemoDrawer : ComponentDrawer
	{
		/// <inheritdoc/>
		public override string DocumentationPageUrl
		{
			get
			{
				return PowerInspectorDocumentation.GetDrawerInfoUrl("script-drawer");
			}
		}

		/// <inheritdoc/>
		protected override void Setup(Component[] setTargets, IParentDrawer setParent, GUIContent setLabel, IInspector setInspector)
		{
			PowerInspectorDocumentation.ShowUrlIfWindowOpen(DocumentationPageUrl);
			base.Setup(setTargets, setParent, setLabel, setInspector);
		}
	}
}