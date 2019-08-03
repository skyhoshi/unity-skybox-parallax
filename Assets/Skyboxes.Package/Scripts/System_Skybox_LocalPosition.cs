using SINeDUSTRIES.Unity.Runtime.PsuedoECS;

using UnityEngine;

namespace SINeDUSTRIES.Unity.Runtime.Skybox {

  /// <summary>
  /// <see cref="Component_Skybox_Property"/>.
  /// </summary>
  public class System_Skybox_LocalPosition : PsuedoSystem {

#region messages

    protected void LateUpdate() {

      Components.ForEach<Component_Skybox_Entities, Component_Skybox_LocalPosition>(
        (c_skyboxEntities, c_property) => {

          Vector3 i_localPosition;
          if (c_skyboxEntities.EntityOrigin == null) {
            // origin does not exist
            // calculate property globally
            i_localPosition = c_skyboxEntities.EntityTarget.transform.position;
          } else {
            // origin exists
            // calculate property relative to origin
            i_localPosition = c_skyboxEntities.EntityTarget.transform.position - c_skyboxEntities.EntityOrigin.transform.position;
          }

          i_localPosition.Scale(c_property.Factor);

          c_skyboxEntities.EntityRender.GetComponentInChildren<Renderer>().material.SetVector("_LocalPosition", i_localPosition);
        }
      );
    }

#endregion
  }
}