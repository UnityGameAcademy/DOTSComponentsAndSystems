using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;

public class WaveSystem : ComponentSystem
{
    protected override void OnUpdate()
    {
        Entities.ForEach((ref Translation trans, ref MoveSpeed moveSpeed, ref WaveData waveData) =>
        {
            float zPosition = waveData.amplitude * math.sin((float)Time.ElapsedTime * moveSpeed.Value
                + trans.Value.x * waveData.xOffset + trans.Value.y * waveData.yOffset);
            //float zPosition = waveData.amplitude * math.sin((float)Time.ElapsedTime * moveSpeed.Value
            //  );
            trans.Value = new float3(trans.Value.x, trans.Value.y, zPosition);
        });
    }
}
