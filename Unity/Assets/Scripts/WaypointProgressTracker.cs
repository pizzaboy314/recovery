using UnityEngine;
using RobotAI;

public class WaypointProgressTracker : MonoBehaviour
{
	
		// This script can be used with any object that is supposed to follow a
		// route marked out by waypoints.

		// This script manages the amount to look ahead along the route,
		// and keeps track of progress and laps.
	
		[SerializeField]
		WaypointCircuit
				circuit;         // A reference to the waypoint-based route we should follow
	
		[SerializeField]
		follow
				followScript;
		[SerializeField]
		float
				lookAheadForTargetOffset = 5;		// The offset ahead along the route that the we will aim for

		//[SerializeField]
		//ProgressStyle progressStyle = ProgressStyle.SmoothAlongRoute; // whether to update the position smoothly along the route (good for curved paths) or just when we reach each waypoint.
		[SerializeField]
		float
				pointToPointThreshold = 4;  // proximity to waypoint which must be reached to switch target to next waypoint : only used in PointToPoint mode.

		public enum ProgressStyle
		{
				SmoothAlongRoute,
				PointToPoint,
		}

		// these are public, readable by other objects - i.e. for an AI to know where to head!
		public WaypointCircuit.RoutePoint targetPoint { get; private set; }

		public WaypointCircuit.RoutePoint speedPoint { get; private set; }

		public WaypointCircuit.RoutePoint progressPoint { get; private set; }

		private float progressDistance;			// The progress round the route, used in smooth mode.
		private int progressNum;				// the current waypoint number, used in point-to-point mode.
		private Vector3 curTarget;

		// setup script properties
		void Start ()
		{
				// we use a transform to represent the point to aim for, and the point which
				// is considered for upcoming changes-of-speed. This allows this component 
				// to communicate this information to the AI without requiring further dependencies.

				// You can manually create a transform and assign it to this component *and* the AI,
				// then this component will update it, and the AI can read it.
				curTarget = followScript.transform.position;
				followScript.toFollowPath = curTarget;
				followScript.trker = this;
				Reset ();

		}

		private int closestIndex ()
		{
				int l = circuit.waypointList.items.Length;
				int ret = 0;
				float dis = Vector3.Distance (circuit.waypointList.items [0].position, this.transform.position);
				float nextDis;
				for (int i = 1; i < l; ++i) {
						nextDis = Vector3.Distance (circuit.waypointList.items [i].position, this.transform.position);
						if (nextDis < dis) {
								dis = nextDis;
								ret = i;
						}
				}
				return (ret + 1) % (circuit.waypointList.items.Length);
		}

		// reset the object to sensible values
		public void Reset ()
		{
				circuit = CircuitRefs.getClosestCourse(this.transform.position);
				progressNum = closestIndex ();
				curTarget = circuit.Waypoints [progressNum].position;
				followScript.toFollowPath = curTarget;
				//target.rotation = circuit.Waypoints [progressNum].rotation;
		}

		void Update ()
		{
				Vector3 targetDelta = curTarget - transform.position;
				if (targetDelta.magnitude < pointToPointThreshold) {
						progressNum = (progressNum + 1) % circuit.Waypoints.Length;
				}

			
				curTarget = circuit.Waypoints [progressNum].position;
				followScript.toFollowPath = curTarget;
				//target.rotation = circuit.Waypoints [progressNum].rotation;

				// get our current progress along the route
				progressPoint = circuit.GetRoutePoint (progressDistance);
				Vector3 progressDelta = progressPoint.position - transform.position;
				if (Vector3.Dot (progressDelta, progressPoint.direction) < 0) {
						progressDistance += progressDelta.magnitude;
				}
		}
	
		void OnDrawGizmos ()
		{
				if (Application.isPlaying) {
						Gizmos.color = Color.green;
						Gizmos.DrawLine (transform.position, curTarget);
						Gizmos.DrawWireSphere (circuit.GetRoutePosition (progressDistance), 1);
						Gizmos.color = Color.yellow;
						//Gizmos.DrawLine (curTarget, curTarget + target.forward);
				}
		}
}
