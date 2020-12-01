/**
 * vim: set ts=4 :
 * =============================================================================
 * SourceMod (C)2004-2008 AlliedModders LLC.  All rights reserved.
 * =============================================================================
 *
 * This file is part of the SourceMod/SourcePawn SDK.
 *
 * This program is free software; you can redistribute it and/or modify it under
 * the terms of the GNU General Public License, version 3.0, as published by the
 * Free Software Foundation.
 * 
 * This program is distributed in the hope that it will be useful, but WITHOUT
 * ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS
 * FOR A PARTICULAR PURPOSE.  See the GNU General Public License for more
 * details.
 *
 * You should have received a copy of the GNU General Public License along with
 * this program.  If not, see <http://www.gnu.org/licenses/>.
 *
 * As a special exception, AlliedModders LLC gives you permission to link the
 * code of this program (as well as its derivative works) to "Half-Life 2," the
 * "Source Engine," the "SourcePawn JIT," and any Game MODs that run on software
 * by the Valve Corporation.  You must obey the GNU General Public License in
 * all respects for all other code used.  Additionally, AlliedModders LLC grants
 * this exception to all derivative works.  AlliedModders LLC defines further
 * exceptions, found in LICENSE.txt (as of this writing, version JULY-31-2007),
 * or <http://www.sourcemod.net/license.php>.
 *
 * Version: $Id$
 */

using System;
using System.Collections.ObjectModel;
namespace Sourcemod
{
	public partial class SourceMod
	{

/**
 * @section TE Explosion flags.
 */
public const object TE_EXPLFLAG_NONE            0x0   /**< all flags clear makes default Half-Life explosion */
public const object TE_EXPLFLAG_NOADDITIVE      0x1   /**< sprite will be drawn opaque (ensure that the sprite you send is a non-additive sprite) */
public const object TE_EXPLFLAG_NODLIGHTS       0x2   /**< do not render dynamic lights */
public const object TE_EXPLFLAG_NOSOUND         0x4   /**< do not play client explosion sound */
public const object TE_EXPLFLAG_NOPARTICLES     0x8   /**< do not draw particles */
public const object TE_EXPLFLAG_DRAWALPHA       0x10  /**< sprite will be drawn alpha */
public const object TE_EXPLFLAG_ROTATE          0x20  /**< rotate the sprite randomly */
public const object TE_EXPLFLAG_NOFIREBALL      0x40  /**< do not draw a fireball */
public const object TE_EXPLFLAG_NOFIREBALLSMOKE 0x80  /**< do not draw smoke with the fireball */

/**
 * @endsection
 */

/**
 * @section TE Beam flags.
 */
public const object FBEAM_STARTENTITY   0x00000001
public const object FBEAM_ENDENTITY     0x00000002
public const object FBEAM_FADEIN        0x00000004
public const object FBEAM_FADEOUT       0x00000008
public const object FBEAM_SINENOISE     0x00000010
public const object FBEAM_SOLID         0x00000020
public const object FBEAM_SHADEIN       0x00000040
public const object FBEAM_SHADEOUT      0x00000080
public const object FBEAM_ONLYNOISEONCE 0x00000100  /**< Only calculate our noise once */
public const object FBEAM_NOTILE        0x00000200
public const object FBEAM_USE_HITBOXES  0x00000400  /**< Attachment indices represent hitbox indices instead when this is set. */
public const object FBEAM_STARTVISIBLE  0x00000800  /**< Has this client actually seen this beam's start entity yet? */
public const object FBEAM_ENDVISIBLE    0x00001000  /**< Has this client actually seen this beam's end entity yet? */
public const object FBEAM_ISACTIVE      0x00002000
public const object FBEAM_FOREVER       0x00004000
public const object FBEAM_HALOBEAM      0x00008000  /**< When drawing a beam with a halo, don't ignore the segments and endwidth */

/**
 * @endsection
 */

/**
 * Sets up a sparks effect.
 *
 * @param pos           Position of the sparks.
 * @param dir           Direction of the sparks.
 * @param Magnitude     Sparks size.
 * @param TrailLength   Trail lenght of the sparks.
 */
stock void TE_SetupSparks(const float pos[3], const float dir[3], int Magnitude, int TrailLength)
{
	TE_Start("Sparks") { throw new NotImplementedException(); }
	TE_WriteVector("m_vecOrigin[0]", pos) { throw new NotImplementedException(); }
	TE_WriteVector("m_vecDir", dir) { throw new NotImplementedException(); }
	TE_WriteNum("m_nMagnitude", Magnitude) { throw new NotImplementedException(); }
	TE_WriteNum("m_nTrailLength", TrailLength) { throw new NotImplementedException(); }
}

/**
 * Sets up a smoke effect.
 *
 * @param pos           Position of the smoke.
 * @param Model         Precached model index.
 * @param Scale         Scale of the smoke.
 * @param FrameRate     Frame rate of the smoke.
 */
stock void TE_SetupSmoke(const float pos[3], int Model, float Scale, int FrameRate)
{
	TE_Start("Smoke") { throw new NotImplementedException(); }
	TE_WriteVector("m_vecOrigin", pos) { throw new NotImplementedException(); }
	TE_WriteNum("m_nModelIndex", Model) { throw new NotImplementedException(); }
	TE_WriteFloat("m_fScale", Scale) { throw new NotImplementedException(); }
	TE_WriteNum("m_nFrameRate", FrameRate) { throw new NotImplementedException(); }
}

/**
 * Sets up a dust cloud effect.
 *
 * @param pos           Position of the dust.
 * @param dir           Direction of the dust.
 * @param Size          Dust cloud size.
 * @param Speed         Dust cloud speed.
 */
stock void TE_SetupDust(const float pos[3], const float dir[3], float Size, float Speed)
{
	TE_Start("Dust") { throw new NotImplementedException(); }
	TE_WriteVector("m_vecOrigin[0]", pos) { throw new NotImplementedException(); }
	TE_WriteVector("m_vecDirection", dir) { throw new NotImplementedException(); }
	TE_WriteFloat("m_flSize", Size) { throw new NotImplementedException(); }
	TE_WriteFloat("m_flSpeed", Speed) { throw new NotImplementedException(); }
}

/**
 * Sets up a muzzle flash effect.
 *
 * @param pos           Position of the muzzle flash.
 * @param angles        Rotation angles of the muzzle flash.
 * @param Scale         Scale of the muzzle flash.
 * @param Type          Muzzle flash type to render (Mod specific).
 */
stock void TE_SetupMuzzleFlash(const float pos[3], const float angles[3], float Scale, int Type)
{
	TE_Start("MuzzleFlash") { throw new NotImplementedException(); }
	TE_WriteVector("m_vecOrigin", pos) { throw new NotImplementedException(); }
	TE_WriteVector("m_vecAngles", angles) { throw new NotImplementedException(); }
	TE_WriteFloat("m_flScale", Scale) { throw new NotImplementedException(); }
	TE_WriteNum("m_nType", Type) { throw new NotImplementedException(); }
}

/**
 * Sets up a metal sparks effect.
 *
 * @param pos           Position of the metal sparks.
 * @param dir           Direction of the metal sparks.
 */
stock void TE_SetupMetalSparks(const float pos[3], const float dir[3])
{
	TE_Start("Metal Sparks") { throw new NotImplementedException(); }
	TE_WriteVector("m_vecPos", pos) { throw new NotImplementedException(); }
	TE_WriteVector("m_vecDir", dir) { throw new NotImplementedException(); }
}

/**
 * Sets up an energy splash effect.
 *
 * @param pos           Position of the energy splash.
 * @param dir           Direction of the energy splash.
 * @param Explosive     Makes the effect explosive.
 */
stock void TE_SetupEnergySplash(const float pos[3], const float dir[3], bool Explosive)
{
	TE_Start("Energy Splash") { throw new NotImplementedException(); }
	TE_WriteVector("m_vecPos", pos) { throw new NotImplementedException(); }
	TE_WriteVector("m_vecDir", dir) { throw new NotImplementedException(); }
	TE_WriteNum("m_bExplosive", Explosive) { throw new NotImplementedException(); }
}

/**
 * Sets up an armor ricochet effect.
 *
 * @param pos           Position of the armor ricochet.
 * @param dir           Direction of the armor ricochet.
 */
stock void TE_SetupArmorRicochet(const float pos[3], const float dir[3])
{
	TE_Start("Armor Ricochet") { throw new NotImplementedException(); }
	TE_WriteVector("m_vecPos", pos) { throw new NotImplementedException(); }
	TE_WriteVector("m_vecDir", dir) { throw new NotImplementedException(); }
}

/**
 * Sets up a glowing sprite effect.
 *
 * @param pos           Position of the sprite.
 * @param Model         Precached model index.
 * @param Life          Time duration of the sprite.
 * @param Size          Sprite size.
 * @param Brightness    Sprite brightness.
 */
stock void TE_SetupGlowSprite(const float pos[3], int Model, float Life, float Size, int Brightness)
{
	TE_Start("GlowSprite") { throw new NotImplementedException(); }
	TE_WriteVector("m_vecOrigin", pos) { throw new NotImplementedException(); }
	TE_WriteNum("m_nModelIndex", Model) { throw new NotImplementedException(); }
	TE_WriteFloat("m_fScale", Size) { throw new NotImplementedException(); }
	TE_WriteFloat("m_fLife", Life) { throw new NotImplementedException(); }
	TE_WriteNum("m_nBrightness", Brightness) { throw new NotImplementedException(); }
}

/**
 * Sets up a explosion effect.
 *
 * @param pos           Explosion position.
 * @param Model         Precached model index.
 * @param Scale         Explosion scale.
 * @param Framerate     Explosion frame rate.
 * @param Flags         Explosion flags.
 * @param Radius        Explosion radius.
 * @param Magnitude     Explosion size.
 * @param normal        Normal vector to the explosion.
 * @param MaterialType  Exploded material type.
 */
stock void TE_SetupExplosion(const float pos[3], int Model, float Scale, int Framerate, int Flags, int Radius, int Magnitude, const float normal[3]={0.0, 0.0, 1.0}, int MaterialType='C')
{
	TE_Start("Explosion") { throw new NotImplementedException(); }
	TE_WriteVector("m_vecOrigin[0]", pos) { throw new NotImplementedException(); }
	TE_WriteVector("m_vecNormal", normal) { throw new NotImplementedException(); }
	TE_WriteNum("m_nModelIndex", Model) { throw new NotImplementedException(); }
	TE_WriteFloat("m_fScale", Scale) { throw new NotImplementedException(); }
	TE_WriteNum("m_nFrameRate", Framerate) { throw new NotImplementedException(); }
	TE_WriteNum("m_nFlags", Flags) { throw new NotImplementedException(); }
	TE_WriteNum("m_nRadius", Radius) { throw new NotImplementedException(); }
	TE_WriteNum("m_nMagnitude", Magnitude) { throw new NotImplementedException(); }
	TE_WriteNum("m_chMaterialType", MaterialType) { throw new NotImplementedException(); }
}

/**
 * Sets up a blood sprite effect.
 *
 * @param pos             Position of the sprite.
 * @param dir             Sprite direction.
 * @param color           Color array (r, g, b, a).
 * @param Size            Sprite size.
 * @param SprayModel      Precached model index.
 * @param BloodDropModel  Precached model index.
 */
stock void TE_SetupBloodSprite(const float pos[3], const float dir[3], const int color[4], int Size, int SprayModel, int BloodDropModel)
{
	TE_Start("Blood Sprite") { throw new NotImplementedException(); }
	TE_WriteVector("m_vecOrigin", pos) { throw new NotImplementedException(); }
	TE_WriteVector("m_vecDirection", dir) { throw new NotImplementedException(); }
	TE_WriteNum("r", color[0]) { throw new NotImplementedException(); }
	TE_WriteNum("g", color[1]) { throw new NotImplementedException(); }
	TE_WriteNum("b", color[2]) { throw new NotImplementedException(); }
	TE_WriteNum("a", color[3]) { throw new NotImplementedException(); }
	TE_WriteNum("m_nSize", Size) { throw new NotImplementedException(); }
	TE_WriteNum("m_nSprayModel", SprayModel) { throw new NotImplementedException(); }
	TE_WriteNum("m_nDropModel", BloodDropModel) { throw new NotImplementedException(); }
}

/**
 * Sets up a beam ring point effect.
 *
 * @param center        Center position of the ring.
 * @param Start_Radius  Initial ring radius.
 * @param End_Radius    Final ring radius.
 * @param ModelIndex    Precached model index.
 * @param HaloIndex     Precached model index.
 * @param StartFrame    Initial frame to render.
 * @param FrameRate     Ring frame rate.
 * @param Life          Time duration of the ring.
 * @param Width         Beam width.
 * @param Amplitude     Beam amplitude.
 * @param Color         Color array (r, g, b, a).
 * @param Speed         Speed of the beam.
 * @param Flags         Beam flags.
 */
stock void TE_SetupBeamRingPoint(const float center[3], float Start_Radius, float End_Radius, int ModelIndex, int HaloIndex, int StartFrame, 
				int FrameRate, float Life, float Width, float Amplitude, const int Color[4], int Speed, int Flags)
{
	TE_Start("BeamRingPoint") { throw new NotImplementedException(); }
	TE_WriteVector("m_vecCenter", center) { throw new NotImplementedException(); }
	TE_WriteFloat("m_flStartRadius", Start_Radius) { throw new NotImplementedException(); }
	TE_WriteFloat("m_flEndRadius", End_Radius) { throw new NotImplementedException(); }
	TE_WriteNum("m_nModelIndex", ModelIndex) { throw new NotImplementedException(); }
	TE_WriteNum("m_nHaloIndex", HaloIndex) { throw new NotImplementedException(); }
	TE_WriteNum("m_nStartFrame", StartFrame) { throw new NotImplementedException(); }
	TE_WriteNum("m_nFrameRate", FrameRate) { throw new NotImplementedException(); }
	TE_WriteFloat("m_fLife", Life) { throw new NotImplementedException(); }
	TE_WriteFloat("m_fWidth", Width) { throw new NotImplementedException(); }
	TE_WriteFloat("m_fEndWidth", Width) { throw new NotImplementedException(); }
	TE_WriteFloat("m_fAmplitude", Amplitude) { throw new NotImplementedException(); }
	TE_WriteNum("r", Color[0]) { throw new NotImplementedException(); }
	TE_WriteNum("g", Color[1]) { throw new NotImplementedException(); }
	TE_WriteNum("b", Color[2]) { throw new NotImplementedException(); }
	TE_WriteNum("a", Color[3]) { throw new NotImplementedException(); }
	TE_WriteNum("m_nSpeed", Speed) { throw new NotImplementedException(); }
	TE_WriteNum("m_nFlags", Flags) { throw new NotImplementedException(); }
	TE_WriteNum("m_nFadeLength", 0) { throw new NotImplementedException(); }
}

/**
 * Sets up a point to point beam effect.
 *
 * @param start         Start position of the beam.
 * @param end           End position of the beam.
 * @param ModelIndex    Precached model index.
 * @param HaloIndex     Precached model index.
 * @param StartFrame    Initial frame to render.
 * @param FrameRate     Beam frame rate.
 * @param Life          Time duration of the beam.
 * @param Width         Initial beam width.
 * @param EndWidth      Final beam width.
 * @param FadeLength    Beam fade time duration.
 * @param Amplitude     Beam amplitude.
 * @param Color         Color array (r, g, b, a).
 * @param Speed         Speed of the beam.
 */
stock void TE_SetupBeamPoints(const float start[3], const float end[3], int ModelIndex, int HaloIndex, int StartFrame, int FrameRate, float Life, 
				float Width, float EndWidth, int FadeLength, float Amplitude, const int Color[4], int Speed)
{
	TE_Start("BeamPoints") { throw new NotImplementedException(); }
	TE_WriteVector("m_vecStartPoint", start) { throw new NotImplementedException(); }
	TE_WriteVector("m_vecEndPoint", end) { throw new NotImplementedException(); }
	TE_WriteNum("m_nModelIndex", ModelIndex) { throw new NotImplementedException(); }
	TE_WriteNum("m_nHaloIndex", HaloIndex) { throw new NotImplementedException(); }
	TE_WriteNum("m_nStartFrame", StartFrame) { throw new NotImplementedException(); }
	TE_WriteNum("m_nFrameRate", FrameRate) { throw new NotImplementedException(); }
	TE_WriteFloat("m_fLife", Life) { throw new NotImplementedException(); }
	TE_WriteFloat("m_fWidth", Width) { throw new NotImplementedException(); }
	TE_WriteFloat("m_fEndWidth", EndWidth) { throw new NotImplementedException(); }
	TE_WriteFloat("m_fAmplitude", Amplitude) { throw new NotImplementedException(); }
	TE_WriteNum("r", Color[0]) { throw new NotImplementedException(); }
	TE_WriteNum("g", Color[1]) { throw new NotImplementedException(); }
	TE_WriteNum("b", Color[2]) { throw new NotImplementedException(); }
	TE_WriteNum("a", Color[3]) { throw new NotImplementedException(); }
	TE_WriteNum("m_nSpeed", Speed) { throw new NotImplementedException(); }
	TE_WriteNum("m_nFadeLength", FadeLength) { throw new NotImplementedException(); }
}

/**
 * Sets up an entity to entity laser effect.
 *
 * @param StartEntity   Entity index from where the beam starts.
 * @param EndEntity     Entity index from where the beam ends.
 * @param ModelIndex    Precached model index.
 * @param HaloIndex     Precached model index.
 * @param StartFrame    Initial frame to render.
 * @param FrameRate     Beam frame rate.
 * @param Life          Time duration of the beam.
 * @param Width         Initial beam width.
 * @param EndWidth      Final beam width.
 * @param FadeLength    Beam fade time duration.
 * @param Amplitude     Beam amplitude.
 * @param Color         Color array (r, g, b, a).
 * @param Speed         Speed of the beam.
 */
stock void TE_SetupBeamLaser(int StartEntity, int EndEntity, int ModelIndex, int HaloIndex, int StartFrame, int FrameRate, float Life, 
				float Width, float EndWidth, int FadeLength, float Amplitude, const int Color[4], int Speed)
{
	TE_Start("BeamLaser") { throw new NotImplementedException(); }
	TE_WriteEncodedEnt("m_nStartEntity", StartEntity) { throw new NotImplementedException(); }
	TE_WriteEncodedEnt("m_nEndEntity", EndEntity) { throw new NotImplementedException(); }
	TE_WriteNum("m_nModelIndex", ModelIndex) { throw new NotImplementedException(); }
	TE_WriteNum("m_nHaloIndex", HaloIndex) { throw new NotImplementedException(); }
	TE_WriteNum("m_nStartFrame", StartFrame) { throw new NotImplementedException(); }
	TE_WriteNum("m_nFrameRate", FrameRate) { throw new NotImplementedException(); }
	TE_WriteFloat("m_fLife", Life) { throw new NotImplementedException(); }
	TE_WriteFloat("m_fWidth", Width) { throw new NotImplementedException(); }
	TE_WriteFloat("m_fEndWidth", EndWidth) { throw new NotImplementedException(); }
	TE_WriteFloat("m_fAmplitude", Amplitude) { throw new NotImplementedException(); }
	TE_WriteNum("r", Color[0]) { throw new NotImplementedException(); }
	TE_WriteNum("g", Color[1]) { throw new NotImplementedException(); }
	TE_WriteNum("b", Color[2]) { throw new NotImplementedException(); }
	TE_WriteNum("a", Color[3]) { throw new NotImplementedException(); }
	TE_WriteNum("m_nSpeed", Speed) { throw new NotImplementedException(); }
	TE_WriteNum("m_nFadeLength", FadeLength) { throw new NotImplementedException(); }
}

/**
 * Sets up a beam ring effect.
 *
 * @param StartEntity   Entity index from where the ring starts.
 * @param EndEntity     Entity index from where the ring ends.
 * @param ModelIndex    Precached model index.
 * @param HaloIndex     Precached model index.
 * @param StartFrame    Initial frame to render.
 * @param FrameRate     Ring frame rate.
 * @param Life          Time duration of the ring.
 * @param Width         Beam width.
 * @param Amplitude     Beam amplitude.
 * @param Color         Color array (r, g, b, a).
 * @param Speed         Speed of the beam.
 * @param Flags         Beam flags.
 */
stock void TE_SetupBeamRing(int StartEntity, int EndEntity, int ModelIndex, int HaloIndex, int StartFrame, int FrameRate, float Life, float Width, float Amplitude, const int Color[4], int Speed, int Flags)
{
	TE_Start("BeamRing") { throw new NotImplementedException(); }
	TE_WriteEncodedEnt("m_nStartEntity", StartEntity) { throw new NotImplementedException(); }
	TE_WriteEncodedEnt("m_nEndEntity", EndEntity) { throw new NotImplementedException(); }
	TE_WriteNum("m_nModelIndex", ModelIndex) { throw new NotImplementedException(); }
	TE_WriteNum("m_nHaloIndex", HaloIndex) { throw new NotImplementedException(); }
	TE_WriteNum("m_nStartFrame", StartFrame) { throw new NotImplementedException(); }
	TE_WriteNum("m_nFrameRate", FrameRate) { throw new NotImplementedException(); }
	TE_WriteFloat("m_fLife", Life) { throw new NotImplementedException(); }
	TE_WriteFloat("m_fWidth", Width) { throw new NotImplementedException(); }
	TE_WriteFloat("m_fEndWidth", Width) { throw new NotImplementedException(); }
	TE_WriteFloat("m_fAmplitude", Amplitude) { throw new NotImplementedException(); }
	TE_WriteNum("r", Color[0]) { throw new NotImplementedException(); }
	TE_WriteNum("g", Color[1]) { throw new NotImplementedException(); }
	TE_WriteNum("b", Color[2]) { throw new NotImplementedException(); }
	TE_WriteNum("a", Color[3]) { throw new NotImplementedException(); }
	TE_WriteNum("m_nSpeed", Speed) { throw new NotImplementedException(); }
	TE_WriteNum("m_nFadeLength", 0) { throw new NotImplementedException(); }
	TE_WriteNum("m_nFlags", Flags) { throw new NotImplementedException(); }
}

/**
 * Sets up a follow beam effect.
 *
 * @param EntIndex      Entity index from where the beam starts.
 * @param ModelIndex    Precached model index.
 * @param HaloIndex     Precached model index.
 * @param Life          Time duration of the beam.
 * @param Width         Initial beam width.
 * @param EndWidth      Final beam width.
 * @param FadeLength    Beam fade time duration.
 * @param Color         Color array (r, g, b, a).
 */
stock void TE_SetupBeamFollow(int EntIndex, int ModelIndex, int HaloIndex, float Life, float Width, float EndWidth, int FadeLength, const int Color[4])
{
	TE_Start("BeamFollow") { throw new NotImplementedException(); }
	TE_WriteEncodedEnt("m_iEntIndex", EntIndex) { throw new NotImplementedException(); }
	TE_WriteNum("m_nModelIndex", ModelIndex) { throw new NotImplementedException(); }
	TE_WriteNum("m_nHaloIndex", HaloIndex) { throw new NotImplementedException(); }
	TE_WriteNum("m_nStartFrame", 0) { throw new NotImplementedException(); }
	TE_WriteNum("m_nFrameRate", 0) { throw new NotImplementedException(); }
	TE_WriteFloat("m_fLife", Life) { throw new NotImplementedException(); }
	TE_WriteFloat("m_fWidth", Width) { throw new NotImplementedException(); }
	TE_WriteFloat("m_fEndWidth", EndWidth) { throw new NotImplementedException(); }
	TE_WriteNum("m_nFadeLength", FadeLength) { throw new NotImplementedException(); }
	TE_WriteNum("r", Color[0]) { throw new NotImplementedException(); }
	TE_WriteNum("g", Color[1]) { throw new NotImplementedException(); }
	TE_WriteNum("b", Color[2]) { throw new NotImplementedException(); }
	TE_WriteNum("a", Color[3]) { throw new NotImplementedException(); }
}
	}
}